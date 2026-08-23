# 04 — Act I: Java Implementation

This chapter shows the same deterministic STS implemented in Java.

Nothing about the **meaning** or **tasks** changes.  
Only the language and tooling change.

This is where HCMD demonstrates **semantic portability**:  
     the STS and PSC survive a language switch without distortion.

## Same STS, Same PSC

We reuse the same STS:

- acquire the dataset  
- validate schema  
- normalize column names  
- handle missing values  
- encode categorical variables  
- scale numerical variables  
- split into train/validation/test sets  
- export prepared data  

The PSC in Java mirrors the C# structure.  
It is **isomorphic**, not idiomatic.

The PSC is not a Java design.  
It is the **same structural blueprint**, expressed in a different language.

---

## PSC as Java Structure

A typical PSC‑derived Java layout looks like:



/src/main/java/hcmd/housing/load/validate/transform/split/exportApp.java

/dataraw/processed/

Each package corresponds to a **Skill (Hut)** that emerged during STS refinement:

- loading  
- validating  
- cleaning and transforming  
- splitting  
- exporting  
  Each class corresponds to a **task** in the STS.

The structure is stable because the STS is deterministic.

---

## Domain Model in Java

The domain model mirrors the C# structure exactly:

- same fields  
- same semantics  
- same responsibilities  

Only the syntax changes.

The PSC ensures that the domain model is **structurally equivalent**, not stylistically adapted.

---

## Services in Java

Each STS task becomes a Java service class:

- a loader  
- a validator  
- a cleaner  
- an encoder  
- a scaler  
- a splitter  
- an exporter  

The responsibilities are identical to the C# services.  
The sequencing is identical.  
The logic is identical.

The **implementation details differ**, but the **structure does not**.

This is semantic portability.

---

## App.java

The entry point sequences the services in the same STS‑defined order:

1. load  
2. validate  
3. clean  
4. encode  
5. scale  
6. split  
7. export  

The order is not chosen by Java conventions.  
It is dictated by the **STS**.

The PSC ensures that the orchestration is the same across languages.

---

## Why This Matters

This chapter demonstrates:

- The STS is **language‑independent**.  
- The PSC can be **ported** without semantic drift.  
- The implementation in C# and Java is **structurally equivalent**.  
- Skills (Huts) remain stable across languages.  

HCMD does not bind you to a language.  
It binds you to a discipline.

The Java implementation is not a translation.  
It is a **reproduction** of the same meaning, tasks, and structure.

This is the proof of HCMD’s portability.


