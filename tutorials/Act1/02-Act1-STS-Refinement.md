# 02 — Act 1: STS Refinement

The Structured Task Specification (STS) is the first explicit artifact in HCMD.
It defines **what must be done**, without describing **how** to do it.

This chapter shows how the STS emerges from the assistant’s semantic interpretation and becomes deterministic through refinement.

---

## From Meaning to Tasks

After the assistant interprets the human goal:

> “Prepare the California Housing dataset for modeling.”

it begins to surface the **first draft** of the STS.

This draft is not yet stable.
It reflects the assistant’s current understanding:

- what “prepare” implies  
- what the dataset contains  
- what modeling requires  
- what assumptions are safe  
- what boundaries must be respected  

The assistant proposes tasks.  
The human clarifies.  
The assistant refines.

This is the HCMD loop in motion.

---

## The First Draft of the STS

The assistant produces an initial list of tasks.
It is incomplete and partially ambiguous.

Typical early tasks might include:

- obtain the dataset  
- inspect its structure  
- clean missing values  
- engineer features  
- split into train/test sets  

These tasks are correct in spirit but not yet **deterministic**.

They contain:

- implicit assumptions  
- unclear boundaries  
- missing conditions  
- ambiguous sequencing  

The human’s role is to expose these gaps.

---

## Refinement Through Dialogue

The human asks clarifying questions:

- What format is the dataset in?  
- What constitutes “cleaning”?  
- Which features are required?  
- How should categorical values be handled?  
- What is the modeling context?  

Each question forces the assistant to refine the STS.

The assistant updates:

- task definitions  
- task order  
- task boundaries  
- task dependencies  

The STS becomes more explicit.  
Ambiguity decreases.  
Determinism increases.

This refinement continues until the assistant can no longer produce contradictions or hidden assumptions.

---

## A Note on Skills (Huts)

As the STS stabilizes, certain tasks begin to cluster naturally:

- dataset acquisition  
- schema validation  
- cleaning and normalization  
- feature preparation  
- dataset splitting  

These clusters are early **Skills** (or **Huts**) — reusable units of meaning that will later become stable structural elements in the PSC.

Act 1 does not formalize Skills.  
It simply lets you **see them forming** as the STS approaches determinism.

---

## Deterministic STS

A deterministic STS has three properties:

1. **Completeness**  
   Every required task is present.

2. **Non‑ambiguity**  
   Each task has a single, clear meaning.

3. **Implementation‑independence**  
   The STS does not assume C#, Python, Java, or any specific tool.

A deterministic STS is stable.  
It can be handed to any implementation environment.

This is the moment where HCMD becomes visible as a discipline.

---

## Example Shape of a Deterministic STS

(Not the full STS — only its structural form.)

A deterministic STS for this goal typically includes:

- acquiring the dataset  
- validating its schema  
- normalizing column names  
- handling missing values  
- encoding categorical variables  
- scaling numerical variables  
- splitting into train/validation/test sets  
- exporting the prepared dataset  

Each task is defined precisely.  
No task depends on hidden assumptions.  
No task implies implementation details.

This is the STS as HCMD intends it.

---

## Why This Matters

The STS is the bridge between:

- **meaning** (implicit)  
- **structure** (explicit)  

Without a deterministic STS:

- the PSC cannot be derived  
- the implementation cannot be stable  
- the code cannot be reproducible across languages  

The STS is the backbone of the discipline.
