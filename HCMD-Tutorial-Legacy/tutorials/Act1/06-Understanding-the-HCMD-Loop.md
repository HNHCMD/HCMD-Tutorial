# 06 — Understanding the HCMD Loop

Act I showed the HCMD loop in motion.  
This chapter explains the loop explicitly.

HCMD is a four‑layer discipline:

1. Meaning  
2. Tasks (STS)  
3. Structure (PSC)  
4. Implementation  

Each layer transforms the previous one.  
None of the layers can be skipped.

---

## 1. Meaning Layer (Implicit)

The loop begins with a human goal.

Example:  
“Prepare the California Housing dataset for modeling.”

The assistant interprets the goal:

- domain  
- intent  
- constraints  
- assumptions  
- missing information  

This interpretation is **implicit**.  
You never write it.  
You only see its effects:

- clarifying questions  
- scope stabilization  
- surfacing of ambiguities  

This is the **Abstract Meaning Layer (AML)** — the semantic substrate of the loop.

---

## 2. Tasks — The Structured Task Specification (STS)

Once meaning stabilizes, the assistant produces the STS.

The STS defines **what must be done**, not how.

A deterministic STS has:

- completeness  
- non‑ambiguity  
- implementation‑independence  

The STS is refined through dialogue until:

- no hidden assumptions remain  
- no task is underspecified  
- no task implies a specific language or tool  

The STS is the backbone of HCMD.

As the STS stabilizes, tasks begin to cluster into **Skills (Huts)** — small, reusable units of meaning that later become structural units in the PSC.

---

## 3. Structure — The Pseudo‑Structural Code (PSC)

The PSC is derived directly from the STS.

PSC is **not**:

- a project template  
- a coding convention  
- a class diagram  
- pseudocode  

PSC is a **language‑agnostic structural blueprint**.

It defines:

- components  
- responsibilities  
- relationships  
- data surfaces  
- execution flow  

The PSC is **isomorphic** to the STS:

- one task → one structural unit  
- one dependency → one structural dependency  
- one sequence → one execution order  

The PSC ensures that implementation cannot drift from the STS.

It is the structural anchor of the discipline.

---

## 4. Implementation Layer

With the PSC in place, implementation becomes deterministic.

GitHub Copilot generates:

- domain models  
- service classes  
- sequencing logic  

The implementation:

- follows the PSC  
- reflects the STS  
- contains no hidden decisions  
- is reproducible across languages  

This is why the C# and Java versions in Act I are structurally identical.

Implementation is the final expression of the loop.

---

## The Loop as a Whole

The HCMD loop is:

**Meaning → STS → PSC → Implementation**

Each layer depends on the previous one.  
Each layer constrains the next.  
Each layer removes ambiguity.

The loop produces:

- clarity  
- determinism  
- reproducibility  
- semantic portability  

This is the discipline.

---

## Why Act I Matters

Act I is not an example.  
It is a demonstration of the loop:

- how meaning forms  
- how tasks emerge  
- how structure stabilizes  
- how implementation becomes reproducible  

Act I shows the discipline in motion before the reader attempts to perform it.

This completes the first act.


