# **HCMD Tutorial — Overview **

This document provides a high‑level overview of the HCMD Tutorial.  
It explains what the tutorial is, how it is structured, and how to read it.

All tutorial content is written under the **HCMD Hut**, the stance used for
producing HCMD artifacts. The HCMD Hut and its blueprint are located in:

```
huts/shop/
```

Huts define the stance, not the content.

---

## **What the Tutorial Is**

The HCMD Tutorial is a structured introduction to the HCMD discipline.  
It shows:

- how the HCMD loop works in practice  
- why the architecture is stable  
- the principle that makes the architecture possible  
- how HCMD remains reproducible across languages and tools  
- how HCMD applies to generative modeling (ActVAE and ActVAEP)

The tutorial is not a reference manual, not a codebase, and not a framework.  
It is a **discipline** expressed through structured documents.

---

## **Structure of the Tutorial**

The tutorial consists of multiple Acts and a supporting appendix.

### **Act 1 — First Contact**  
A performance of the HCMD loop.  
Shows meaning → STS → PSC → implementation → portability.

### **Act 2 — Architecture**  
Explains the two‑engine model, layer boundaries, determinism, and failure modes.

### **Act 3 — Principle**  
Introduces the cognitive separation principle that stabilizes the architecture.

### **Act 4 — Stability Over Time**  
Explains why HCMD remains reproducible across languages, tools, and years.

### **ActVAE — HCMD Applied to Variational Autoencoders**  
Applies the HCMD loop to the canonical VAE.  
Introduces Meaning → STS → PSC → Implementation → Interpretability for generative models.

### **ActVAEP — Advanced VAE Variants in HCMD**  
Extends ActVAE to the full family of VAE variants:  
β‑VAE, FactorVAE, DIP‑VAE, Hierarchical VAE, Flow‑VAE, Causal VAE.  
Demonstrates how HCMD scales to complex model families.

### **Appendix**  
Operational notes, environment setup, comparisons, and hut‑related guidance.

---

## **How to Read the Tutorial**

Read Acts in order.  
Each Act builds on the previous one.

- **Act 1** shows the loop in motion.  
- **Act 2** explains the architecture behind the loop.  
- **Act 3** explains the principle that makes the architecture possible.  
- **Act 4** explains why the discipline remains stable over time.  
- **ActVAE** shows how HCMD applies to a real model family.  
- **ActVAEP** shows how HCMD scales to advanced variants.

The appendix is optional and can be consulted as needed.

---

## **Public vs Private Material**

The tutorial root contains both public and private reference files.

### **Public**  
These files are part of the tutorial:

- `Reference-Copilot-Quick-Education.md`  
- `Reference-HCMD-Deep-Conceptual-Guide.md`  
- `Reference-HCMD-vs-XP.md`  
- `Reference-Meta-Guide.md`  
- `TERMINOLOGY.md`  
- All Act folders (Act1–ActVAEP)

### **Private‑Only**  
Drafts, alternates, and historical versions.  
They are kept for internal reference and stored in private folders (not included in public releases).

These files are not part of the public tutorial.

---

## **Purpose of the Tutorial**

The tutorial provides:

- a complete demonstration of the HCMD loop  
- the architectural and cognitive principles behind the discipline  
- the temporal stability model  
- a full application to generative modeling (ActVAE, ActVAEP)  
- supporting references for readers and contributors  

It is the canonical introduction to HCMD.

---
