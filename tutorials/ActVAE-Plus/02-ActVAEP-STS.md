**02 – STS (Structured Task Specification) for Advanced VAE Variants**
======================================================================

This STS defines the deterministic tasks required to train and analyze advanced VAE variants.  
Each variant modifies the canonical VAE workflow by adding, removing, or refining specific tasks.  
The STS remains **language‑agnostic**, **implementation‑free**, and **fully deterministic**.

The purpose of this section is to express _what must be done_ for each variant, without describing _how_ it is done.

* * *

**1. Shared Tasks for All VAE Variants**
========================================

These tasks are inherited from the canonical VAE and apply to all variants in ActVAEP.

1. **EncodeInput**
   
   * Compute latent mean and variance for each input.

2. **SampleLatent**
   
   * Sample latent vector using reparameterization.

3. **DecodeLatent**
   
   * Reconstruct input from latent vector.

4. **ComputeReconstructionLoss**
   
   * Measure difference between input and reconstruction.

5. **ComputeKLDivergence**
   
   * Measure divergence between latent distribution and prior.

6. **AggregateLossTerms**
   
   * Combine reconstruction and KL losses.

7. **UpdateModelParameters**
   
   * Apply gradients to encoder and decoder.

8. **EvaluateReconstructionQuality**
   
   * Assess reconstruction accuracy.

9. **PerformLatentTraversal**
   
   * Modify latent dimensions and observe changes.

10. **AnalyzeLatentGeometry**
* Inspect structure of latent space.

These tasks form the baseline STS for all variants.

* * *

**2. β‑VAE Tasks**
==================

β‑VAE modifies the KL term to encourage disentanglement.

11. **ApplyBetaScalingToKL**
* Multiply KL divergence by β > 1.
12. **AdjustLossBalance**
* Rebalance reconstruction vs. KL contributions.
13. **MonitorDisentanglementEmergence**
* Track separation of latent factors during training.

* * *

**3. FactorVAE Tasks**
======================

FactorVAE introduces a discriminator to penalize correlated latent dimensions.

14. **GenerateLatentSamplesForDiscriminator**
* Produce real and permuted latent samples.
15. **TrainLatentDiscriminator**
* Train discriminator to distinguish real vs. permuted latents.
16. **ComputeTotalCorrelationPenalty**
* Estimate total correlation using discriminator output.
17. **IncorporateTCPenaltyIntoLoss**
* Add total correlation penalty to overall loss.
18. **StabilizeAdversarialTraining**
* Ensure encoder and discriminator training remain balanced.

* * *

**4. DIP‑VAE Tasks**
====================

DIP‑VAE aligns latent covariance with a target structure.

19. **ComputeLatentCovariance**
* Estimate covariance of latent means across batch.
20. **ComputeCovarianceDeviation**
* Measure deviation from target covariance (usually diagonal).
21. **ApplyCovarianceRegularization**
* Add penalty proportional to covariance deviation.
22. **MonitorAxisAlignment**
* Track alignment of latent axes with semantic factors.

* * *

**5. Hierarchical VAE Tasks**
=============================

Hierarchical VAEs introduce multiple latent layers.

23. **EncodeGlobalLatent**
* Compute top‑level latent distribution.
24. **EncodeLocalLatent**
* Compute lower‑level latent distributions conditioned on global latent.
25. **SampleHierarchicalLatents**
* Sample from each latent layer.
26. **DecodeHierarchicalLatents**
* Reconstruct input using multi‑level latent structure.
27. **ComputeHierarchicalKLTerms**
* Compute KL divergence for each latent layer.
28. **AggregateHierarchicalLoss**
* Combine reconstruction and multi‑level KL terms.
29. **AnalyzeHierarchicalFactors**
* Identify global vs. local semantic factors.

* * *

**6. Flow‑Based VAE Tasks**
===========================

Flow‑VAEs use invertible transformations to create flexible latent distributions.

30. **ApplyFlowTransformToLatent**
* Transform latent vector using flow layers.
31. **ComputeFlowLogDetJacobian**
* Compute log‑determinant of Jacobian for flow transformation.
32. **AdjustKLForFlowPrior**
* Modify KL divergence to account for transformed prior.
33. **MonitorLatentDistributionShape**
* Track geometry of transformed latent space.

* * *

**7. Causal VAE Tasks**
=======================

Causal VAEs interpret latent dimensions as causal factors.

34. **IdentifyCausalLatentVariables**
* Determine which latent dimensions correspond to causal factors.
35. **ConstructLatentCausalGraph**
* Build directed graph representing causal relationships.
36. **PerformLatentIntervention**
* Modify a latent dimension and observe causal effect.
37. **GenerateCounterfactualReconstruction**
* Produce reconstruction under hypothetical latent changes.
38. **EvaluateCausalConsistency**
* Verify that interventions produce consistent causal effects.

* * *

**8. Summary of Variant‑Specific Tasks**
========================================

| Variant              | Key STS Additions                                 |
| -------------------- | ------------------------------------------------- |
| **β‑VAE**            | KL scaling, disentanglement monitoring            |
| **FactorVAE**        | discriminator training, total correlation penalty |
| **DIP‑VAE**          | covariance matching, axis alignment               |
| **Hierarchical VAE** | multi‑level encoding, hierarchical KL             |
| **Flow‑VAE**         | flow transforms, Jacobian terms                   |
| **Causal VAE**       | causal graph, interventions, counterfactuals      |

Each variant extends the canonical VAE STS with tasks that reflect its conceptual meaning.

* * *


