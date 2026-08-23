# **TERMINOLOGY (Modern, 2026 Edition)**

### **Human‑Centered Meta Development — Canonical Glossary**

This glossary defines the stable terminology used throughout HCMD.  
All terms are engine‑neutral and language‑agnostic.

---

## **HCMD — Human‑Centered Meta Development**

A deterministic, language‑agnostic development discipline that separates Meaning, Structure, and Execution.  
Defines a four‑layer pipeline: Meaning → STS → PSC → Implementation.

---

## **Meaning Layer**

The human intention behind a system.  
Not written explicitly.  
Clarified through interaction.  
Defines *what the system is for*.

---

## **STS — Structured Task Specification**

A deterministic, implementation‑free specification of **what must be done**.  
Language‑agnostic.  
Refined by the semantic engine.  
Contains no structural or execution mechanics.

---

## **PSC — Pseudo‑Structural Code**

A declarative, language‑agnostic description of **how the work is organized structurally**.  
Defines components, responsibilities, relationships, boundaries, invariants, and conceptual data/control surfaces.  
Not pseudocode.  
Not UML.  
Not a schema.  
Not a class diagram.  
Refined by the structural engine.

---

## **AML — Abstract Meaning Layer**

The semantic foundation layer inside HMD.  
Represents stabilized meaning after refinement.  
Not directly executable.

---

## **HMD — Hierarchical Meaning Document**

The unified specification combining **AML (semantic)** and **PSC (structural)**.  
The final, language‑portable artifact.  
If a specification cannot survive language change, it is not a valid HMD.

---

## **Implementation**

Executable code generated from PSC by the structural engine.  
Language‑specific.  
Not part of the specification.  
The result of the specification.

---

## **Two‑Engine Principle**

HCMD requires two distinct engines:  

- **Semantic Engine** — Meaning + STS refinement  
- **Structural Engine** — PSC + Implementation refinement  

One engine cannot perform both roles without violating determinism and boundary separation.

---

## **Engine‑Neutrality**

HCMD does not depend on any specific AI system.  
Copilot App + GitHub Copilot is a reference implementation, not a requirement.  
Any future system satisfying HCMD constraints may implement the pipeline.

---

## **Language Portability Principle**

STS and PSC must be language‑agnostic.  
The same STS + PSC pair must produce semantically equivalent implementations in any programming language.

---

## **Deterministic Pipeline**

The HCMD pipeline must regenerate the same STS, PSC, and Implementation under repeated refinement.  
No unstable loops.  
No agentic drift.  
No cross‑layer contamination.

---

## **Structural Invariants**

Rules governing the stability of PSC:  

- component boundaries  
- responsibility separation  
- relationship correctness  
- data/control surface clarity  
- no execution mechanics inside PSC

---

## **Semantic Invariants**

Rules governing the stability of Meaning and STS:  

- intent clarity  
- task completeness  
- deterministic refinement  
- no structural or implementation leakage into STS

---

## **Hut — Human‑Understandable Template**

A Human‑Understandable Template used as a conceptual workspace for refining Meaning and Structure.  
A hut is not a pipeline layer; it is a cognitive environment where humans and engines stabilize reasoning.  
Historically, the hut concept evolved from **Skill**, but its modern definition is independent and formalized.

---

## **Skill**

A reusable semantic unit that supports Meaning or Structure refinement.  
Skills operate inside huts.

---

## **InjectML**

A compact, deterministic demonstration of the HCMD pipeline.  
Used as the primary example in the modern tutorial.

---

## **EntropyML**

An optional advanced example applying HCMD to conceptual modeling domains.




