**03 – PSC (Pseudo‑Structural Code) for Advanced VAE Variants**
===============================================================

This PSC defines the structural components and relationships required to implement advanced VAE variants.  
It is **language‑agnostic**, **implementation‑free**, and **deterministic**.  
Each variant extends the canonical VAE structure by adding or modifying modules, flows, or loss components.

The PSC expresses **how the work is organized structurally**, not how it is coded.

* * *

**1. Shared PSC for All VAE Variants**
======================================

    Component Encoder:
        Input: x
        Output: μ(x), σ²(x)
    
    Component Reparameterizer:
        Input: μ, σ²
        Output: z
    
    Component Decoder:
        Input: z
        Output: x̂
    
    Component ReconstructionLoss:
        Input: x, x̂
        Output: L_recon
    
    Component KLDivergence:
        Input: q(z|x), p(z)
        Output: L_KL
    
    Component LossAggregator:
        Input: L_recon, L_KL, (optional variant-specific terms)
        Output: L_total
    
    Component Trainer:
        Input: L_total
        Action: Update Encoder, Decoder, and variant-specific modules

This is the baseline structure inherited by all variants.

* * *

**2. β‑VAE PSC**
================

β‑VAE modifies the KL term.
    Component BetaScaler:
        Input: L_KL
        Parameter: β > 1
        Output: β * L_KL
    Modify LossAggregator:
        Input: L_recon, β * L_KL
        Output: L_total

Structural meaning:  
KL term is scaled before aggregation.

* * *

**3. FactorVAE PSC**
====================

FactorVAE introduces a discriminator to estimate total correlation.
    Component LatentDiscriminator:
        Input: z_real, z_permuted
        Output: D_score
    Component TotalCorrelationEstimator:
        Input: D_score
        Output: L_TC

    Modify LossAggregator:
        Input: L_recon, L_KL, γ * L_TC
        Output: L_total

    Component AdversarialTrainer:
        Action: 
            Update Encoder to minimize L_TC
            Update Discriminator to maximize discrimination accuracy

Structural meaning:  
A new adversarial branch penalizes correlated latent dimensions.

* * *

**4. DIP‑VAE PSC**
==================

DIP‑VAE aligns latent covariance with a target structure.
    Component LatentCovarianceEstimator:
        Input: μ(x) across batch
        Output: Σ_latent
    Component CovarianceDeviation:
        Input: Σ_latent, Σ_target (diagonal)
        Output: L_cov

    Modify LossAggregator:
        Input: L_recon, L_KL, λ * L_cov
        Output: L_total

Structural meaning:  
A covariance‑matching module regularizes latent geometry.

* * *

**5. Hierarchical VAE PSC**
===========================

Hierarchical VAEs introduce multiple latent layers.
    Component GlobalEncoder:
        Input: x
        Output: μ_g, σ²_g
    Component LocalEncoder:
        Input: x, z_g
        Output: μ_l, σ²_l

    Component HierarchicalReparameterizer:
        Input: (μ_g, σ²_g), (μ_l, σ²_l)
        Output: z_g, z_l

    Component HierarchicalDecoder:
        Input: z_g, z_l
        Output: x̂

    Component HierarchicalKL:
        Input: q(z_g|x), q(z_l|x,z_g), p(z_g), p(z_l|z_g)
        Output: L_KL_global, L_KL_local

    Modify LossAggregator:
        Input: L_recon, L_KL_global, L_KL_local
        Output: L_total

Structural meaning:  
Latent space becomes multi‑level, with dependencies between layers.

* * *

**6. Flow‑Based VAE PSC**
=========================

Flow‑VAEs apply invertible transformations to latent variables.
    Component FlowTransform:
        Input: z
        Output: z_flow
    Component LogDetJacobian:
        Input: FlowTransform
        Output: log|det J|

    Modify KLDivergence:
        Input: q(z_flow|x), p(z_flow), log|det J|
        Output: L_KL_flow

    Modify Decoder:
        Input: z_flow
        Output: x̂

Structural meaning:  
Latent distribution is reshaped by invertible flows.

* * *

**7. Causal VAE PSC**
=====================

Causal VAEs interpret latent dimensions as causal factors.
    Component CausalLatentIdentifier:
        Input: z
        Output: z_causal (subset or structured partition)
    Component CausalGraph:
        Nodes: z_causal_i
        Edges: Directed causal relations

    Component LatentIntervention:
        Input: z_causal, intervention_spec
        Output: z_intervened

    Component CounterfactualDecoder:
        Input: z_intervened
        Output: x̂_counterfactual

    Component CausalConsistencyEvaluator:
        Input: x̂, x̂_counterfactual
        Output: CausalConsistencyScore

Structural meaning:  
Latent space is structured as a causal graph with intervention capability.

* * *

**8. Summary of PSC Extensions**
================================

| Variant              | PSC Additions                                      |
| -------------------- | -------------------------------------------------- |
| **β‑VAE**            | KL scaling module                                  |
| **FactorVAE**        | discriminator, TC estimator, adversarial trainer   |
| **DIP‑VAE**          | covariance estimator + deviation module            |
| **Hierarchical VAE** | multi‑level encoders, decoders, KL modules         |
| **Flow‑VAE**         | flow transform + Jacobian module                   |
| **Causal VAE**       | causal graph, intervention, counterfactual decoder |

Each variant extends the canonical VAE structure with modules that reflect its conceptual meaning and STS tasks.


