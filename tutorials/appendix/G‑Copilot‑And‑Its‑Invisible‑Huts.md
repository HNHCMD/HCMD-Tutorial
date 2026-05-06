# Appendix G — Copilot and Its Invisible Huts

Copilot works through **huts**: internal reasoning modes that shape how it
interprets a request. A hut is not a skill, not a tool, and not a knowledge
module. It is a **stance** — a way of thinking that narrows Copilot’s focus and
stabilizes its behavior.

Huts are invisible by design.  
You never select them manually.  
Copilot infers the hut from your request.

---

## Why Huts Exist

A single reasoning mode cannot serve every task.  
Writing code, analyzing structure, refining meaning, and editing prose each
require different cognitive constraints.

Huts provide these constraints.

A hut defines:

- what Copilot pays attention to  
- what it ignores  
- how it structures its internal reasoning  
- how it interprets ambiguity  
- how it maintains consistency across turns  

Huts do **not** contain knowledge.  
They contain **rules of attention and interpretation**.

---

## The HCMD Hut

This tutorial is written under the **HCMD Hut**, the stance used for producing
HCMD artifacts. The HCMD Hut is defined in:
    huts/shop/

It specifies how Copilot should think when working inside the HCMD discipline:

- meaning and structure must remain separate  
- the STS must remain implementation‑free  
- the PSC must remain declarative  
- determinism must be preserved  
- no agentic drift is allowed  

The HCMD Hut is not part of the HCMD loop.  
It is the stance from which the loop is performed.

---

## HutShop and HutLab

The repository contains two hut spaces:

- **HutShop** (`huts/shop/`)  
  The official, stable huts used in the tutorial.

- **HutLab** (`huts/lab@/`)  
  A private workshop for experimental huts, drafts, and prototypes.

Readers only interact with HutShop.  
HutLab is intentionally private.

---

## Why Huts Are Invisible

Copilot does not expose huts because:

1. **They are internal reasoning modes**, not user‑facing features.  
2. **They must be inferred**, not selected.  
3. **They must remain stable**, even as the surface interface changes.  
4. **They prevent drift**, especially in long documents or multi‑step tasks.  

If huts were exposed as toggles, users would misinterpret them as tools or
skills. They are neither.

A hut is a **cognitive contract**.

---

## Why Alignment Matters

When Copilot misidentifies the hut — for example, treating an HCMD document as
a general writing task — the output becomes inconsistent:

- structure collapses  
- meaning leaks into implementation  
- determinism is lost  
- the loop becomes unstable  

Aligning Copilot’s hut ensures that:

- the correct stance is active  
- the reasoning mode matches the document  
- the refinement process remains coherent  

Appendix H explains how to align the hut in Word when Copilot drifts.

---

## What to Remember

- Huts are **invisible reasoning modes**.  
- The HCMD Hut defines the stance for this tutorial.  
- HutShop contains the official huts.  
- HutLab is private and experimental.  
- Alignment ensures stability and prevents drift.  

Huts are not part of the HCMD loop.  
They are the **cognitive environment** in which the loop is performed.
