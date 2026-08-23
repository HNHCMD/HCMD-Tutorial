# **04 – Implementation (Advanced VAE Variants)**

This section shows **minimal implementation patterns** for advanced VAE variants:

- β‑VAE  
- FactorVAE  
- DIP‑VAE  
- Hierarchical VAE  
- Flow‑VAE  
- Causal VAE  

The goal is not to provide production‑ready code, but to show **how the PSC becomes concrete code** in a clean, faithful way.

All examples assume a canonical VAE baseline with:

- `Encoder(x) → μ, logvar`  
- `Reparameterize(μ, logvar) → z`  
- `Decoder(z) → x_recon`  
- `recon_loss(x, x_recon)`  
- `kl_loss(μ, logvar)`  

---

## **1. Baseline VAE Skeleton**

```python
class VAE(nn.Module):
    def __init__(self):
        super().__init__()
        self.encoder = Encoder()
        self.decoder = Decoder()

    def encode(self, x):
        mu, logvar = self.encoder(x)
        return mu, logvar

    def reparameterize(self, mu, logvar):
        std = torch.exp(0.5 * logvar)
        eps = torch.randn_like(std)
        return mu + eps * std

    def decode(self, z):
        return self.decoder(z)

    def forward(self, x):
        mu, logvar = self.encode(x)
        z = self.reparameterize(mu, logvar)
        x_recon = self.decode(z)
        return x_recon, mu, logvar

def recon_loss(x, x_recon):
    return F.binary_cross_entropy(x_recon, x, reduction="sum")

def kl_loss(mu, logvar):
    return -0.5 * torch.sum(1 + logvar - mu.pow(2) - logvar.exp())
```

Training loop (baseline):

```python
for x in dataloader:
    x_recon, mu, logvar = model(x)
    L_recon = recon_loss(x, x_recon)
    L_KL = kl_loss(mu, logvar)
    L_total = L_recon + L_KL
    optimizer.zero_grad()
    L_total.backward()
    optimizer.step()
```

All variants extend this pattern.

---

## **2. β‑VAE Implementation**

**PSC element:** `BetaScaler` on KL term.

```python
class BetaVAE(VAE):
    def __init__(self, beta=4.0):
        super().__init__()
        self.beta = beta

    def loss(self, x):
        x_recon, mu, logvar = self.forward(x)
        L_recon = recon_loss(x, x_recon)
        L_KL = kl_loss(mu, logvar)
        L_total = L_recon + self.beta * L_KL
        return L_total, L_recon, L_KL
```

Training:

```python
for x in dataloader:
    L_total, L_recon, L_KL = model.loss(x)
    optimizer.zero_grad()
    L_total.backward()
    optimizer.step()
```

This directly implements:

- **STS:** ApplyBetaScalingToKL, AdjustLossBalance  
- **PSC:** BetaScaler + modified LossAggregator  

---

## **3. FactorVAE Implementation**

**PSC elements:** `LatentDiscriminator`, `TotalCorrelationEstimator`, `AdversarialTrainer`.

### **3.1. Discriminator**

```python
class LatentDiscriminator(nn.Module):
    def __init__(self, z_dim):
        super().__init__()
        self.net = nn.Sequential(
            nn.Linear(z_dim, 256),
            nn.ReLU(),
            nn.Linear(256, 1)
        )

    def forward(self, z):
        return self.net(z)
```

### **3.2. FactorVAE Model**

```python
class FactorVAE(VAE):
    def __init__(self, z_dim, gamma=10.0):
        super().__init__()
        self.discriminator = LatentDiscriminator(z_dim)
        self.gamma = gamma

    def encode_and_sample(self, x):
        mu, logvar = self.encode(x)
        z = self.reparameterize(mu, logvar)
        return z, mu, logvar
```

### **3.3. Total Correlation Estimation (simplified)**

```python
def total_correlation_loss(discriminator, z):
    # z: [batch, z_dim]
    # permute each dimension independently to create "fake" samples
    z_perm = []
    for d in range(z.size(1)):
        z_perm.append(z[:, d][torch.randperm(z.size(0))])
    z_perm = torch.stack(z_perm, dim=1)

    D_real = discriminator(z)
    D_perm = discriminator(z_perm)

    # discriminator loss (binary classification)
    D_loss = - (torch.log(torch.sigmoid(D_real)).mean() +
                torch.log(1 - torch.sigmoid(D_perm)).mean())

    # total correlation estimate (encoder side)
    TC = (D_real - D_perm).mean()
    return D_loss, TC
```

### **3.4. Training Loop (Two Optimizers)**

```python
enc_dec_optimizer = optim.Adam(
    list(model.encoder.parameters()) + list(model.decoder.parameters()), lr=1e-3
)
disc_optimizer = optim.Adam(model.discriminator.parameters(), lr=1e-3)

for x in dataloader:
    # ----- Encoder/Decoder step -----
    z, mu, logvar = model.encode_and_sample(x)
    x_recon = model.decode(z)

    L_recon = recon_loss(x, x_recon)
    L_KL = kl_loss(mu, logvar)

    D_loss, TC = total_correlation_loss(model.discriminator, z.detach())
    # encoder wants to minimize TC
    L_total = L_recon + L_KL + model.gamma * TC

    enc_dec_optimizer.zero_grad()
    L_total.backward()
    enc_dec_optimizer.step()

    # ----- Discriminator step -----
    z, _, _ = model.encode_and_sample(x)
    D_loss, _ = total_correlation_loss(model.discriminator, z)

    disc_optimizer.zero_grad()
    D_loss.backward()
    disc_optimizer.step()
```

This implements:

- **STS:** GenerateLatentSamplesForDiscriminator, TrainLatentDiscriminator, ComputeTotalCorrelationPenalty, IncorporateTCPenaltyIntoLoss, StabilizeAdversarialTraining  
- **PSC:** LatentDiscriminator, TotalCorrelationEstimator, AdversarialTrainer  

---

## **4. DIP‑VAE Implementation**

**PSC elements:** `LatentCovarianceEstimator`, `CovarianceDeviation`.

### **4.1. Covariance Regularization**

```python
def covariance_penalty(mu, lambda_offdiag=1.0, lambda_diag=1.0):
    # mu: [batch, z_dim]
    batch, z_dim = mu.size()
    mu_centered = mu - mu.mean(dim=0, keepdim=True)
    cov = (mu_centered.t() @ mu_centered) / batch  # [z_dim, z_dim]

    diag = torch.diag(cov)
    offdiag = cov - torch.diag(diag)

    L_offdiag = (offdiag ** 2).sum()
    L_diag = ((diag - 1.0) ** 2).sum()  # target variance = 1

    return lambda_offdiag * L_offdiag + lambda_diag * L_diag
```

### **4.2. DIP‑VAE Model**

```python
class DIPVAE(VAE):
    def __init__(self, lambda_offdiag=10.0, lambda_diag=5.0):
        super().__init__()
        self.lambda_offdiag = lambda_offdiag
        self.lambda_diag = lambda_diag

    def loss(self, x):
        x_recon, mu, logvar = self.forward(x)
        L_recon = recon_loss(x, x_recon)
        L_KL = kl_loss(mu, logvar)
        L_cov = covariance_penalty(
            mu,
            lambda_offdiag=self.lambda_offdiag,
            lambda_diag=self.lambda_diag
        )
        L_total = L_recon + L_KL + L_cov
        return L_total, L_recon, L_KL, L_cov
```

This implements:

- **STS:** ComputeLatentCovariance, ComputeCovarianceDeviation, ApplyCovarianceRegularization, MonitorAxisAlignment  
- **PSC:** LatentCovarianceEstimator, CovarianceDeviation, modified LossAggregator  

---

## **5. Hierarchical VAE Implementation**

**PSC elements:** `GlobalEncoder`, `LocalEncoder`, `HierarchicalReparameterizer`, `HierarchicalDecoder`, `HierarchicalKL`.

### **5.1. Model Structure**

```python
class HierarchicalVAE(nn.Module):
    def __init__(self):
        super().__init__()
        self.global_encoder = GlobalEncoder()   # x → μ_g, logvar_g
        self.local_encoder = LocalEncoder()     # x, z_g → μ_l, logvar_l
        self.decoder = HierarchicalDecoder()    # z_g, z_l → x_recon

    def encode_global(self, x):
        mu_g, logvar_g = self.global_encoder(x)
        return mu_g, logvar_g

    def encode_local(self, x, z_g):
        mu_l, logvar_l = self.local_encoder(x, z_g)
        return mu_l, logvar_l

    def reparameterize(self, mu, logvar):
        std = torch.exp(0.5 * logvar)
        eps = torch.randn_like(std)
        return mu + eps * std

    def forward(self, x):
        mu_g, logvar_g = self.encode_global(x)
        z_g = self.reparameterize(mu_g, logvar_g)

        mu_l, logvar_l = self.encode_local(x, z_g)
        z_l = self.reparameterize(mu_l, logvar_l)

        x_recon = self.decoder(z_g, z_l)
        return x_recon, (mu_g, logvar_g), (mu_l, logvar_l)
```

### **5.2. Hierarchical KL**

For simplicity, assume independent priors:

```python
def kl_loss_gaussian(mu, logvar):
    return -0.5 * torch.sum(1 + logvar - mu.pow(2) - logvar.exp())

def hierarchical_kl(mu_g, logvar_g, mu_l, logvar_l):
    L_KL_global = kl_loss_gaussian(mu_g, logvar_g)
    L_KL_local = kl_loss_gaussian(mu_l, logvar_l)
    return L_KL_global, L_KL_local
```

### **5.3. Loss**

```python
def hierarchical_vae_loss(model, x):
    x_recon, (mu_g, logvar_g), (mu_l, logvar_l) = model(x)
    L_recon = recon_loss(x, x_recon)
    L_KL_global, L_KL_local = hierarchical_kl(mu_g, logvar_g, mu_l, logvar_l)
    L_total = L_recon + L_KL_global + L_KL_local
    return L_total, L_recon, L_KL_global, L_KL_local
```

This implements:

- **STS:** EncodeGlobalLatent, EncodeLocalLatent, SampleHierarchicalLatents, DecodeHierarchicalLatents, ComputeHierarchicalKLTerms, AggregateHierarchicalLoss  
- **PSC:** GlobalEncoder, LocalEncoder, HierarchicalReparameterizer, HierarchicalDecoder, HierarchicalKL  

---

## **6. Flow‑Based VAE Implementation**

**PSC elements:** `FlowTransform`, `LogDetJacobian`, modified KL.

Here we use a simple planar flow as a placeholder.

### **6.1. Planar Flow Module**

```python
class PlanarFlow(nn.Module):
    def __init__(self, z_dim):
        super().__init__()
        self.u = nn.Parameter(torch.randn(z_dim))
        self.w = nn.Parameter(torch.randn(z_dim))
        self.b = nn.Parameter(torch.zeros(1))

    def forward(self, z):
        # z: [batch, z_dim]
        linear = z @ self.w + self.b  # [batch]
        h = torch.tanh(linear)
        z_flow = z + self.u * h.unsqueeze(1)

        # log|det J|
        psi = (1 - torch.tanh(linear) ** 2) * self.w  # [batch, z_dim]
        log_det_jac = torch.log(torch.abs(1 + psi @ self.u) + 1e-8)
        return z_flow, log_det_jac
```

### **6.2. Flow‑VAE Model**

```python
class FlowVAE(VAE):
    def __init__(self, z_dim, n_flows=2):
        super().__init__()
        self.flows = nn.ModuleList([PlanarFlow(z_dim) for _ in range(n_flows)])

    def apply_flows(self, z):
        log_det_sum = 0.0
        for flow in self.flows:
            z, log_det = flow(z)
            log_det_sum = log_det_sum + log_det
        return z, log_det_sum

    def forward(self, x):
        mu, logvar = self.encode(x)
        z0 = self.reparameterize(mu, logvar)
        zK, log_det_sum = self.apply_flows(z0)
        x_recon = self.decode(zK)
        return x_recon, mu, logvar, log_det_sum
```

### **6.3. Flow‑Aware KL**

For simplicity, treat the prior as standard normal and adjust with log‑det:

```python
def flow_kl_loss(mu, logvar, log_det_sum):
    # base KL
    base_kl = kl_loss(mu, logvar)
    # adjust with flow log-det (sign depends on formulation; here we subtract)
    return base_kl - log_det_sum.sum()
```

### **6.4. Loss**

```python
def flow_vae_loss(model, x):
    x_recon, mu, logvar, log_det_sum = model(x)
    L_recon = recon_loss(x, x_recon)
    L_KL_flow = flow_kl_loss(mu, logvar, log_det_sum)
    L_total = L_recon + L_KL_flow
    return L_total, L_recon, L_KL_flow
```

This implements:

- **STS:** ApplyFlowTransformToLatent, ComputeFlowLogDetJacobian, AdjustKLForFlowPrior, MonitorLatentDistributionShape  
- **PSC:** FlowTransform, LogDetJacobian, modified KLDivergence  

---

## **7. Causal VAE Implementation (Conceptual Skeleton)**

Causal VAE is more conceptual; here we show a **minimal structural pattern** that matches the PSC.

**PSC elements:** `CausalLatentIdentifier`, `CausalGraph`, `LatentIntervention`, `CounterfactualDecoder`.

### **7.1. Partition Latent into Causal Blocks**

```python
class CausalVAE(VAE):
    def __init__(self, z_dim, causal_indices):
        super().__init__()
        self.z_dim = z_dim
        self.causal_indices = causal_indices  # e.g., [0, 1, 2] are causal

    def split_causal(self, z):
        z_causal = z[:, self.causal_indices]
        z_other = torch.clone(z)
        z_other[:, self.causal_indices] = 0.0
        return z_causal, z_other
```

### **7.2. Simple Causal Graph Placeholder**

In practice, this would be learned or specified; here we keep it symbolic:

```python
class CausalGraph:
    def __init__(self, adjacency_matrix):
        self.A = adjacency_matrix  # [n_causal, n_causal]

    def intervene(self, z_causal, index, new_value):
        z_new = z_causal.clone()
        z_new[:, index] = new_value
        # (optional) propagate effects according to A
        return z_new
```

### **7.3. Counterfactual Generation**

```python
def generate_counterfactual(model, x, causal_graph, index, new_value):
    x_recon, mu, logvar = model(x)
    z = model.reparameterize(mu, logvar)
    z_causal, z_other = model.split_causal(z)

    z_causal_intervened = causal_graph.intervene(z_causal, index, new_value)
    z_intervened = z_other.clone()
    z_intervened[:, model.causal_indices] = z_causal_intervened

    x_cf = model.decode(z_intervened)
    return x_recon, x_cf
```

This implements:

- **STS:** IdentifyCausalLatentVariables, ConstructLatentCausalGraph, PerformLatentIntervention, GenerateCounterfactualReconstruction, EvaluateCausalConsistency (via downstream analysis)  
- **PSC:** CausalLatentIdentifier, CausalGraph, LatentIntervention, CounterfactualDecoder  

---

## **8. Closing Remarks**

- Each variant’s implementation is a **direct realization of its PSC modules**.  
- The **Meaning Layer** explains *why* the variant exists.  
- The **STS** defines *what tasks* must be done.  
- The **PSC** defines *how the system is structurally organized*.  
- The **Implementation** here shows *one concrete way* to realize that structure in code.

ActVAEP’s Implementation layer is intentionally minimal and structural, so that:

- the code remains readable,  
- the mapping to PSC is obvious,  
- and the door stays open for language‑agnostic re‑implementation (C#, Java, etc.) using the same HCMD layers.

---


