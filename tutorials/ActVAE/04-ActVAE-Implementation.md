**04 – ActVAE Implementation**
==============================

This section provides a minimal implementation of the Variational Autoencoder (VAE) that follows the PSC defined in Section 03.  
The goal is not performance or completeness.  
The goal is **faithfulness to the PSC**:

* Encoder → Mean, Variance
* LatentSpace → Distribution, Sampling
* Decoder → Reconstruction
* Loss → Reconstruction + KL
* Training → Backprop + Update
* Evaluation → Reconstruction
* Interpretability → Latent manipulation (basic)

This implementation uses Python‑style pseudocode inspired by PyTorch, but the structure is language‑agnostic.  
A C# implementation would follow the same PSC.

* * *

**1. Minimal VAE Model Structure**
==================================

    class VAE(nn.Module):
        def __init__(self, latent_dim):
            super().__init__()
    
            # Encoder
            self.encoder = nn.Sequential(
                nn.Linear(784, 400),
                nn.ReLU(),
            )
            self.mean_layer = nn.Linear(400, latent_dim)
            self.var_layer  = nn.Linear(400, latent_dim)
    
            # Decoder
            self.decoder = nn.Sequential(
                nn.Linear(latent_dim, 400),
                nn.ReLU(),
                nn.Linear(400, 784),
                nn.Sigmoid()
            )
    
        def encode(self, x):
            h = self.encoder(x)
            mean = self.mean_layer(h)
            logvar = self.var_layer(h)
            return mean, logvar
    
        def sample(self, mean, logvar):
            eps = torch.randn_like(mean)
            std = torch.exp(0.5 * logvar)
            return mean + eps * std
    
        def decode(self, z):
            return self.decoder(z)
    
        def forward(self, x):
            mean, logvar = self.encode(x)
            z = self.sample(mean, logvar)
            recon = self.decode(z)
            return recon, mean, logvar

This implementation follows the PSC exactly:

* `encode` → ComputeMean + ComputeVariance
* `sample` → FormDistribution + Sample + RecordNoise
* `decode` → Reconstruct

* * *

**2. Loss Functions**
=====================

    def loss_function(recon, x, mean, logvar):
        recon_error = F.binary_cross_entropy(recon, x, reduction='sum')
        kl = -0.5 * torch.sum(1 + logvar - mean.pow(2) - logvar.exp())
        return recon_error + kl

This matches the PSC:

* ReconstructionError
* KLDivergence
* CombineLoss

* * *

**3. Training Loop**
====================

    optimizer = torch.optim.Adam(model.parameters(), lr=1e-3)
    
    for epoch in range(num_epochs):
        for batch in dataloader:
            x = batch.view(-1, 784)
    
            recon, mean, logvar = model(x)
            loss = loss_function(recon, x, mean, logvar)
    
            optimizer.zero_grad()
            loss.backward()
            optimizer.step()

This matches the PSC:

* Backpropagate
* UpdateParameters
* Iterate

* * *

**4. Evaluation (Deterministic Encoding)**
==========================================

    with torch.no_grad():
        mean, logvar = model.encode(x)
        recon = model.decode(mean)

This corresponds to STS task 17:

* EncodeWithoutSampling

* * *

**5. Basic Latent Interventions**
=================================

    def intervene(z, dim, delta):
        z_new = z.clone()
        z_new[:, dim] += delta
        return model.decode(z_new)

This matches PSC:

* Interpretability.Intervene

* * *

**6. Notes on Implementation Scope**
====================================

This implementation is intentionally minimal:

* no convolutional layers
* no advanced priors
* no hierarchical latents
* no β‑VAE or InfoVAE variants
* no disentanglement metrics

These belong in Section 05 (Interpretability & Recent Evolution).

The purpose of this section is to show:

> **How the PSC becomes real code.**

* * *

**7. Summary**
==============

This implementation:

* follows the PSC exactly
* is minimal but complete
* is faithful to the Meaning Layer
* is compatible with modern VAE research
* can be ported to C#, Java, or any language

The next section, **05 – Interpretability and Recent Evolution**, will compare:

* HCMD’s meaning‑first interpretation
* modern VAE interpretability research
* latent geometry
* causal interventions
* disentanglement metrics
* latent circuits

This is where ActVAE becomes truly powerful.

* * *
