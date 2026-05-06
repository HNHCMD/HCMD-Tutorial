# HCMD — Canonical Terminology

This glossary defines the core terms of the HCMD discipline.  
All definitions are minimal, stable, and implementation‑free.

---

## HCMD (Human‑Centered Meta‑Development)

A discipline that separates:

- Meaning (implicit human goal)
- STS (Structured Task Specification)
- PSC (Pseudo‑Structural Code)
- Implementation (final code or artifact)

HCMD is not a framework, not a methodology, and not an agentic system.

---

## Meaning

The human’s implicit intention.  
Never written explicitly.  
Interpreted by Engine A.  
Source of all refinement.

Meaning is not structure and not implementation.

---

## STS (Structured Task Specification)

A deterministic, implementation‑free description of **what** must be done.  
Language‑agnostic.  
Refined from Meaning by Engine A.

STS contains:

- tasks  
- constraints  
- invariants  
- required outcomes  

STS does **not** contain:

- data structures  
- control flow  
- implementation mechanics  
- language constructs  

---

## PSC (Pseudo‑Structural Code)

A declarative, language‑agnostic structural representation of the system.  
Derived from STS by Engine B.

PSC defines:

- components  
- responsibilities  
- boundaries  
- flows  
- invariants  
- conceptual data/control surfaces  

PSC is **not** pseudocode, not UML, not a class diagram, not a schema.

PSC is the structural anchor of HCMD.

---

## Implementation

The final code or artifact generated from PSC.  
Language‑specific.  
Mechanically reproducible.  
Regenerable in multiple languages.

Implementation is not structure and not meaning.

---

## HMD (Hierarchical Meaning Document)

A unified document containing:

- Meaning (via AML)
- PSC (structure)

STS is not part of the HMD.  
STS is an operational bridge used during generation.

---

## AML (Abstract Meaning Layer)

The semantic foundation of Meaning.  
Implicit.  
Not written directly.  
Referenced in HMD.

---

## Two‑Engine Architecture

The architectural foundation of HCMD.

- **Engine A**: Meaning → STS  
- **Engine B**: STS → PSC → Implementation  

The engines must remain cognitively separate.

If one engine attempts to do both, determinism collapses.

---

## Cognitive Separation Principle

Meaning and Execution require different cognitive modes.  
They must remain separate for HCMD to be stable.

This principle explains:

- why two engines are required  
- why PSC must be declarative  
- why STS must be implementation‑free  
- why drift breaks the loop  

This is the conceptual core of Act 3.

---

## Determinism

A requirement for all HCMD transformations.

Determinism ensures:

- reproducibility  
- portability  
- long‑term stability  
- cross‑language equivalence  

Non‑determinism is treated as structural failure.

---

## Language Portability Principle

The same STS + PSC pair must produce semantically equivalent implementations in:

- C#  
- Java  
- Python  
- or any other language  

If a specification cannot survive a language change, it contains implementation mechanics that do not belong in STS or PSC.

---

## XML (for PSC)

The canonical medium for PSC storage.

Chosen because it is:

- deterministic  
- explicit  
- diff‑friendly  
- tooling‑agnostic  
- stable across decades  

XML preserves PSC over time.

---

## Drift

A deviation from the correct reasoning stance.

Signs:

- narrative tone  
- speculative additions  
- mixing layers  
- loss of determinism  
- implementation leaking into STS  
- structure leaking into Meaning  

Drift is corrected by alignment.

---

## Alignment

The act of restoring Copilot to the correct reasoning stance.

For HCMD work:

- “Align to the HCMD Hut stance.”

Alignment modifies stance, not content.

---

## Hut

An internal reasoning stance used by Copilot.  
Not a tool, not a skill, not a prompt template.

A hut defines:

- what Copilot pays attention to  
- what it ignores  
- how it interprets ambiguity  
- how it maintains consistency  

Huts are invisible by design.

---

## HCMD Hut

The stance used for all HCMD work.  
Defined in:
    huts/shop/

It enforces:

- cognitive separation  
- deterministic structure  
- layer boundaries  
- non‑agentic behavior  

The HCMD Hut defines the stance, not the content.

---

## HutShop

The directory containing official, stable huts:
    huts/shop/

Used by the tutorial.  
Public and canonical.

---

## HutLab

The directory for experimental huts:
    huts/lab@/

Private.  
Not part of the tutorial.

---

## Stance

The cognitive mode Copilot uses to interpret a request.  
Determines reasoning behavior.  
Defined by the active hut.

---

## Private‑Only Material

Drafts, alternates, and historical versions.  
Not part of the public tutorial.  
Stored in:
    archive-2026.04@/

---

## HCMD Loop

The full cycle:

Meaning → STS → PSC → Implementation → Regeneration

Demonstrated in Act 1.

---

## Regeneration

Reproducing the implementation from PSC.  
Used to verify determinism and portability.

---

## Agentic Systems (contrast)

Systems that:

- decide  
- plan  
- act  
- optimize  

HCMD is not agentic.  
HCMD is a discipline, not an agent.

---

## Summary

This glossary defines the stable conceptual vocabulary of HCMD.  
All terms are minimal, deterministic, and implementation‑free.
