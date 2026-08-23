# **HCMD Tutorial Overview (2026 Edition)**

### **Human‑Centered Meta Development**

The HCMD Tutorial introduces the modern architecture of **Human‑Centered Meta Development**, a deterministic, language‑agnostic development pipeline built for co‑intelligence systems.  
This document provides a concise map of the entire framework.

HCMD is structured around four layers:

1. **Meaning Layer**  
2. **STS (Structured Task Specification)**  
3. **PSC (Pseudo‑Structural Code)**  
4. **Implementation**

These layers form a reproducible pipeline that separates *semantic intent* from *structural organization* and *execution mechanics*.  
The result is a development method that is stable, portable, and resistant to agentic drift.

---

## **HCMD Is Engine‑Neutral**

HCMD does **not** depend on any specific AI system.  
It defines a conceptual discipline and a deterministic pipeline that can be implemented by **any** pair of engines capable of:

- semantic refinement  
- structural refinement  
- strict boundary separation  
- deterministic regeneration  
- non‑agentic execution  

Our current reference implementation uses **Copilot App + GitHub Copilot**, because they map cleanly onto the four HCMD layers.  
But HCMD itself is **AI‑neutral** and **engine‑agnostic**.

Any future AI system that satisfies the same constraints can implement HCMD.

---

## **1. Meaning Layer**

The Meaning Layer captures the human intention behind a system.  
It is not written explicitly.  
It is inferred, clarified, and stabilized through interaction.

Meaning defines **what the system is for**, not how it works.

Meaning is refined into STS through deterministic reasoning.

---

## **2. STS — Structured Task Specification**

STS is the first explicit artifact in HCMD.

It defines **what must be done**, in complete detail, without describing **how** it is done.

Characteristics:

- deterministic  
- implementation‑free  
- language‑agnostic  
- reproducible  
- refined with the semantic engine (Copilot App in our reference implementation)

STS is the operational bridge between Meaning and Structure.

---

## **3. PSC — Pseudo‑Structural Code**

PSC defines **how the work is organized structurally**, without specifying syntax or execution.

PSC is:

- declarative  
- structural  
- language‑agnostic  
- implementation‑free  
- not pseudocode  
- not UML  
- not a schema  
- not a class diagram  

PSC describes components, responsibilities, relationships, boundaries, invariants, and conceptual data/control surfaces.

PSC is refined with the structural engine (GitHub Copilot in our reference implementation).

---

## **4. HMD — Hierarchical Meaning Document**

HMD unifies:

- **AML** (the semantic foundation layer)  
- **PSC** (the structural foundation layer)

HMD is the final specification of the system.  
It is the artifact that survives language changes.

If a specification cannot survive a language change with its logic intact, it contains implementation mechanics that do not belong in STS or PSC.

---

## **5. Implementation**

Implementation is the final layer.

The structural engine generates code from PSC:

- language‑specific  
- syntax‑correct  
- reproducible  
- IDE‑native completions

Implementation is not part of the specification.  
It is the *result* of the specification.

---

## **6. The Two‑Engine Principle**

HCMD requires two distinct engines:

### **Semantic Engine**

Meaning + STS refinement

### **Structural Engine**

PSC + Implementation refinement

This separation ensures:

- determinism  
- reproducibility  
- stability  
- no unstable loops  
- no agentic drift  
- no cross‑layer contamination

Our reference implementation uses Copilot App (semantic) and GitHub Copilot (structural), but HCMD itself is engine‑neutral.

---

## **7. Language Portability Principle**

Both STS and PSC are language‑agnostic.

The same STS + PSC pair produces semantically equivalent implementations in:

- C#  
- Java  
- Python  
- any language

This is a correctness signal.  
If a specification breaks under language change, it is not a valid HCMD specification.

---

## **8. Deterministic Pipeline**

HCMD is designed for:

- reproducible regeneration  
- stable iteration  
- deterministic refinement  
- long‑term maintainability  
- cross‑language consistency  
- conceptual clarity

HCMD avoids unstable loops common in agentic systems by enforcing strict separation between Meaning, Structure, and Execution.

---

## **9. Examples**

The modern HCMD Tutorial begins with:

### **InjectML**

A compact, deterministic demonstration of the full HCMD pipeline.

Optional advanced example:

### **EntropyML**

A conceptual modeling example showing HCMD applied to abstract systems.

---

## **10. Legacy Tutorial**

The previous tutorial has been archived under:

```
HCMD-Tutorial-Legacy/
```

It documents the early HCMD era and is preserved for historical continuity.

---

## **Next Steps**

The tutorial will expand with:

- updated Acts  
- modern terminology  
- structured examples  
- HMD references  
- PSC correctness guides  
- STS refinement guides  
- language portability demonstrations  

This overview is the entry point for all future HCMD Tutorial content.


