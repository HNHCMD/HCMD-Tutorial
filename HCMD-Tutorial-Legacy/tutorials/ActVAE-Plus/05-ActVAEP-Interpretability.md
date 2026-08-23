**05 – Interpretability in Advanced VAE Variants (ActVAEP)**
============================================================

Interpretability in ActVAEP is not an afterthought.  
It is the _reason_ these variants exist.

Each variant strengthens a different dimension of interpretability:

* **β‑VAE** → disentangled meaning
* **FactorVAE** → independent factors
* **DIP‑VAE** → geometric clarity
* **Hierarchical VAE** → multi‑level meaning
* **Flow‑VAE** → flexible latent geometry
* **Causal VAE** → intervention‑based understanding

This section defines **how to interpret** each variant using HCMD principles:

* Meaning Layer → what the latent space _means_
* STS → what interpretability tasks must be done
* PSC → what structural components support interpretation
* Implementation → what concrete operations reveal meaning

Interpretability is the _fifth hut_ in the ActVAEP village.

* * *

**1. Interpretability Principles (HCMD‑Aligned)**
=================================================

ActVAEP uses the following interpretability principles:

1. **Latent Meaning Visibility**  
   Each latent dimension must correspond to a semantic factor.

2. **Axis Stability**  
   Latent axes should not rotate unpredictably across training runs.

3. **Factor Independence**  
   Changing one latent dimension should not unintentionally affect others.

4. **Hierarchical Separation**  
   Global and local factors must be distinguishable.

5. **Geometric Transparency**  
   Latent space geometry should reflect data structure.

6. **Causal Legibility**  
   Interventions in latent space must produce predictable counterfactuals.

These principles unify all variants under a single interpretability philosophy.

* * *

**2. β‑VAE Interpretability**
=============================

β‑VAE strengthens interpretability by enforcing **disentanglement**.

### **Interpretability Signals**

* Each latent dimension tends to represent a single factor.
* Traversing one dimension changes only one semantic attribute.
* Latent axes become stable across training runs.

### **Interpretability Tools**

* **Latent Traversal**  
  Vary one dimension while fixing others.

* **Factor Sensitivity Analysis**  
  Measure how each latent dimension affects reconstruction.

### **Interpretability Outcome**

β‑VAE provides the **cleanest axis‑aligned meaning** among all variants.

* * *

**3. FactorVAE Interpretability**
=================================

FactorVAE enforces **statistical independence** between latent dimensions.

### **Interpretability Signals**

* Latent dimensions become uncorrelated.
* Interactions between factors are minimized.
* Disentanglement improves even when β‑VAE struggles.

### **Interpretability Tools**

* **Total Correlation Heatmap**  
  Visualize correlation between latent dimensions.

* **Discriminator Score Analysis**  
  Inspect how well the discriminator distinguishes permuted latents.

### **Interpretability Outcome**

FactorVAE provides **independence‑based meaning**, complementing β‑VAE’s pressure‑based meaning.

* * *

**4. DIP‑VAE Interpretability**
===============================

DIP‑VAE aligns latent covariance with a **diagonal target structure**.

### **Interpretability Signals**

* Latent axes align with semantic axes.
* Covariance matrix becomes diagonal.
* Geometry becomes stable and predictable.

### **Interpretability Tools**

* **Covariance Matrix Visualization**  
  Inspect diagonal dominance.

* **Axis Alignment Score**  
  Measure deviation from target covariance.

### **Interpretability Outcome**

DIP‑VAE provides **geometric interpretability**, making latent space easier to analyze.

* * *

**5. Hierarchical VAE Interpretability**
========================================

Hierarchical VAEs separate **global** and **local** factors.

### **Interpretability Signals**

* Top‑level latents capture global style or structure.
* Lower‑level latents capture fine‑grained details.
* Traversing global latents changes broad attributes.
* Traversing local latents changes small details.

### **Interpretability Tools**

* **Global vs. Local Traversal**  
  Compare effects of modifying each layer.

* **Hierarchical Factor Maps**  
  Visualize which parts of the image each latent layer controls.

### **Interpretability Outcome**

Hierarchical VAEs provide **multi‑level meaning**, matching human perception.

* * *

**6. Flow‑VAE Interpretability**
================================

Flow‑VAEs reshape latent space using invertible transformations.

### **Interpretability Signals**

* Latent distribution matches data structure more closely.
* Clusters, manifolds, and curved geometry become visible.
* Latent space becomes more expressive without losing structure.

### **Interpretability Tools**

* **Flow‑Transformed Latent Visualization**  
  Plot z₀ vs. z_K to see geometric deformation.

* **Jacobian Analysis**  
  Inspect how flows warp latent space.

### **Interpretability Outcome**

Flow‑VAEs provide **geometric flexibility** while preserving interpretability.

* * *

**7. Causal VAE Interpretability**
==================================

Causal VAEs interpret latent dimensions as **causal factors**.

### **Interpretability Signals**

* Each causal latent corresponds to a real‑world cause.
* Interventions produce predictable counterfactuals.
* Causal graph reveals relationships between factors.

### **Interpretability Tools**

* **Latent Intervention**  
  Modify one causal latent and observe effect.

* **Counterfactual Generation**  
  Produce “what if” reconstructions.

* **Causal Graph Visualization**  
  Show directed edges between latent factors.

### **Interpretability Outcome**

Causal VAEs provide **the strongest interpretability**:  
latent dimensions become _causes_, not just factors.

* * *

**8. Unified Interpretability Workflow (ActVAEP)**
==================================================

ActVAEP defines a unified workflow for interpreting any variant:

1. **Inspect Latent Geometry**
   
   * covariance
   * independence
   * flow deformation

2. **Perform Latent Traversals**
   
   * axis‑aligned
   * hierarchical
   * causal

3. **Analyze Reconstruction Sensitivity**
   
   * which latent affects which part of the output

4. **Evaluate Factor Independence**
   
   * correlation
   * total correlation
   * covariance deviation

5. **Generate Counterfactuals (if causal)**
   
   * intervene
   * decode
   * compare

6. **Summarize Meaning**
   
   * assign semantic labels to latent dimensions

This workflow is **variant‑agnostic** and **HCMD‑aligned**.

* * *

**9. Summary of Interpretability Across Variants**
==================================================

| Variant              | Interpretability Strength |
| -------------------- | ------------------------- |
| **β‑VAE**            | clean disentanglement     |
| **FactorVAE**        | independence of factors   |
| **DIP‑VAE**          | geometric axis alignment  |
| **Hierarchical VAE** | multi‑level meaning       |
| **Flow‑VAE**         | flexible latent geometry  |
| **Causal VAE**       | causal interpretability   |

ActVAEP unifies these into a single interpretability framework.


