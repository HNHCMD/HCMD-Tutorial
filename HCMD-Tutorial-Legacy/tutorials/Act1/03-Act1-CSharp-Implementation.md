# 03 — Act I: C# Implementation

This chapter shows how the deterministic STS becomes a concrete C# project.

The STS defines **what must be done**.  
The implementation defines **how it is done**.  
The bridge between them is the **PSC — Pseudo‑Structural Code**.

The PSC is derived from the STS, not from language habits or personal style.

---

## From STS to PSC

The deterministic STS for preparing the California Housing dataset contains tasks such as:

- acquire the dataset  
- validate schema  
- normalize column names  
- handle missing values  
- encode categorical variables  
- scale numerical variables  
- split into train/validation/test sets  
- export prepared data  

The PSC translates these tasks into a stable, language‑agnostic structure that GitHub Copilot can implement in C#.

The PSC is not pseudocode.  
It is not a class diagram.  
It is a **structural blueprint**: components, responsibilities, and flows.

---

## The PSC as Structure

A typical PSC for this STS includes conceptual components such as:

- `DatasetLoader`  
- `SchemaValidator`  
- `ColumnNormalizer`  
- `MissingValueHandler`  
- `CategoricalEncoder`  
- `NumericScaler`  
- `DatasetSplitter`  
- `PreparedDatasetExporter`  

Each component corresponds to a **Skill (Hut)** that emerged during STS refinement:

- loading  
- validating  
- cleaning  
- preparing  
- splitting  
- exporting  

The PSC arranges these Skills into a deterministic structure.

The PSC does not specify:

- C# syntax  
- method signatures  
- library choices  
- file formats  

It specifies **structure only**.

---

## From PSC to C# Project Layout

Once the PSC is stable, GitHub Copilot can generate a clean C# project.

A typical layout looks like:

```
/src
  /Load
    DatasetLoader.cs
    SchemaValidator.cs

  /Transform
    ColumnNormalizer.cs
    MissingValueHandler.cs
    CategoricalEncoder.cs
    NumericScaler.cs

  /Split
    DatasetSplitter.cs

  /Export
    PreparedDatasetExporter.cs

Program.cs
```

This structure is not invented by the human.  
It is **derived mechanically** from the PSC.

The human does not design the project.  
The human designs the **meaning** and the **tasks**.  
The PSC and implementation follow.

---

## Deterministic Implementation

With the PSC in place, GitHub Copilot can generate:

- classes  
- methods  
- data models  
- control flow  
- file I/O  
- error handling  

The implementation is deterministic because:

- the STS is complete  
- the PSC is explicit  
- the structure is unambiguous  
- the responsibilities are clear  

Different runs of GitHub Copilot produce the **same** structure.  
Different languages (C#, Java, Python) produce **equivalent** implementations.

This is the core promise of HCMD.

---

## Why This Matters

The C# implementation is not the goal.  
It is the **proof** that:

- meaning was understood  
- tasks were deterministic  
- structure was stable  
- Skills were coherent  
- the PSC was correct  

The implementation is the final movement of the Act I performance.

---

## What Comes Next

In the next chapter, the same PSC is implemented in **Java** to demonstrate semantic portability.

This shows that HCMD is not tied to a language —  
the structure survives the translation.

```


