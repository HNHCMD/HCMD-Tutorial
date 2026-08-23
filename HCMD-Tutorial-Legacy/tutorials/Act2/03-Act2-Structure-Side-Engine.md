# 03 — The Structure‑Side Engine (GitHub Copilot)

The structure‑side engine is responsible for everything that happens **after** the STS is complete.  
It does not interpret meaning.  
It does not resolve ambiguity.  
It does not negotiate intent.

Its role is mechanical:

- derive the PSC  
- generate deterministic implementation  
- maintain structural consistency  
- enforce reproducibility  

This engine works because the STS has already removed ambiguity.  
It receives a complete, implementation‑free specification and turns it into structure and code.

---

## What the structure‑side engine produces

- **PSC — Pseudo‑Structural Code**  
  A language‑agnostic structural blueprint derived directly from the STS.  
  It defines components, responsibilities, relationships, and execution flow.

- **Implementation**  
  Deterministic code that follows the PSC.

- **Reproducible outputs**  
  The same STS always yields the same structure and code.

The structure‑side engine is not creative.  
It is not interpretive.  
It is not semantic.

It is **structural**.

---

## Skills and the Structure‑Side Engine

Skills (Huts) originate in the Meaning‑Side Engine as reusable semantic units.  
When the STS becomes deterministic, these Skills cross the boundary **only as structure**:

- a Skill becomes a PSC component  
- a cluster of Skills becomes a PSC grouping  
- Skill relationships become structural dependencies  

The structure‑side engine does not refine Skills.  
It **receives** them as fixed units and arranges them mechanically.

---

## Why this engine must be separate

If the structure‑side engine touches meaning, it introduces drift.  
If it tries to interpret intent, it introduces ambiguity.  
If it mixes structure with meaning, it contaminates the STS.

The structure‑side engine must remain below the boundary:

- no meaning  
- no negotiation  
- no reinterpretation  

Its strength is precision, not interpretation.

---

## Why GitHub Copilot fits this role

GitHub Copilot is optimized for:

- code generation  
- structural patterns  
- language conventions  
- deterministic transformations  

It excels when the input is unambiguous and complete.  
This is exactly what the STS provides.

The structure‑side engine works because it receives **structure‑ready input**.  
It fails when it receives **meaning‑level ambiguity**.

This separation is the foundation of the HCMD loop.


