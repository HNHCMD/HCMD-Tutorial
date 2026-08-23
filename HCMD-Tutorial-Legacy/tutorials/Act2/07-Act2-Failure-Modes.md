# **07 — Failure Modes**

The Two‑Copilot Model exists to prevent structural collapse in the HCMD loop.  
When the engines mix roles or the boundary is crossed, the loop becomes unstable.  
These failures are predictable, repeatable, and avoidable.

This chapter lists the primary failure modes and the structural reason each one occurs.

---

## **1. Meaning Drift**

**Cause:**  
The structure‑side engine attempts to interpret intent.

**Effect:**  
- inconsistent outputs  
- shifting assumptions  
- loss of semantic clarity  
- STS becomes unstable  

Meaning drift occurs whenever ambiguity is processed below the boundary.

---

## **2. Structural Contamination**

**Cause:**  
The meaning‑side engine incorporates implementation details too early.

**Effect:**  
- STS becomes biased by structure  
- refinement becomes constrained  
- intent becomes distorted  
- determinism is weakened  

This happens when code or conventions appear above the boundary.

---

## **3. Implementation Leakage**

**Cause:**  
The structure‑side engine introduces details not present in the STS.

**Effect:**  
- unexpected files  
- unexpected patterns  
- inconsistent code generation  
- loss of reproducibility  

Leakage occurs when the structure‑side engine improvises instead of following the STS.

---

## **4. Ambiguous STS**

**Cause:**  
Refinement ends too early on the meaning side.

**Effect:**  
- PSC becomes unstable  
- code generation becomes inconsistent  
- repeated runs produce different results  
- the loop loses determinism  

An ambiguous STS is the most common failure mode.

---

## **5. Mixed Layers in a Single Engine**

**Cause:**  
One assistant attempts to handle both meaning and execution.

**Effect:**  
- meaning and structure collapse into each other  
- refinement and implementation interleave  
- the loop becomes non‑reproducible  
- the human loses control  

This is the failure mode the Two‑Copilot Model is designed to prevent.

---

## **6. Boundary Violations**

**Cause:**  
Artifacts cross the meaning/structure boundary in the wrong direction.

**Effect:**  
- meaning influenced by implementation  
- implementation influenced by ambiguity  
- STS loses purity  
- PSC loses determinism  

Boundary violations destabilize the entire loop.

---

## **Why these failures matter**

Each failure mode is a symptom of the same underlying issue:

> **Meaning and execution must remain separate.**

When the engines stay in their domains, the loop is stable.  
When they mix, the loop collapses.

The failure modes are not errors in usage.  
They are structural consequences of violating the architecture.
