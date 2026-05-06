# HCMD Blueprint

This blueprint defines the identity and purpose of the HCMD Hut.  
It contains the essential knowledge required to reconstruct the hut after context loss.

## Purpose

To provide the canonical definitions and structural principles of HCMD.

## Core Definitions

- **Meaning** — the implicit human intention behind a task.
- **STS (Structured Task Specification)** — a deterministic, implementation-free list of tasks defining WHAT must be done.
- **PSC (Pseudo-Structural Code)** — a language-agnostic structural representation of components, responsibilities, flows, and invariants.
- **Implementation** — the actual code generated from STS + PSC.

## The HCMD Loop

Meaning → STS → PSC → Implementation  
This loop is unidirectional and non-reversible.

## Principles

- **Language-Agnostic Principle**  
  STS and PSC must survive a language change without semantic alteration.

- **Temporal Stability Principle**  
  HCMD artifacts must remain valid across time; no hidden state or drift.

- **No-Looping Principle**  
  Higher layers must not depend on lower layers.

## When to Load This Blueprint

- When reconstructing HCMD context after loss.
- When activating the HCMD Hut for the first time in a session.
- When verifying correctness of HCMD documents.

This blueprint is the identity card of the HCMD Hut.


