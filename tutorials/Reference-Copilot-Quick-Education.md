# Reference — Copilot Quick Education

This document explains how to work with Copilot inside the HCMD discipline.
It is not a training script, not a configuration file, and not a prompt
template. It describes the **stance** and **context discipline** required for
stable HCMD work.

All HCMD work is performed under the **HCMD Hut**, defined in:
    huts/shop/

The hut defines the reasoning stance.  
It does not define content.

---

## 1. Copilot Does Not Learn From You

Copilot does not accumulate knowledge from your edits or corrections.  
It does not “improve” over time.  
It does not store preferences.

Instead, Copilot:

- interprets your request  
- infers the correct hut  
- applies the stance  
- produces an answer consistent with that stance  

HCMD stability comes from **your control of context**, not Copilot’s memory.

---

## 2. The HCMD Hut

The HCMD Hut enforces the cognitive constraints required for the discipline:

- meaning and structure must remain separate  
- the STS must remain implementation‑free  
- the PSC must remain declarative  
- determinism must be preserved  
- no agentic drift is allowed  

When Copilot is aligned to the HCMD Hut, the loop is stable.

When Copilot drifts into a general writing hut, the loop collapses.

Appendix G explains huts.  
Appendix H explains alignment.

---

## 3. How to Keep Copilot Stable

HCMD stability depends on **context discipline**:

1. **State the layer explicitly**  
   (“This is STS”, “This is PSC”, “This is conceptual.”)

2. **State the task explicitly**  
   (“Refine”, “Rewrite structurally”, “Do not add content.”)

3. **State the boundaries explicitly**  
   (“No implementation”, “No narrative”, “No new ideas.”)

4. **Realign the hut when drift appears**  
   (“Align to the HCMD Hut stance.”)

5. **Keep the working set small**  
   Copilot is stable when the local context is clean.

HCMD is not prompt engineering.  
It is **context engineering**.

---

## 4. What Copilot Is Responsible For

Copilot is responsible for:

- interpreting your request  
- applying the correct hut  
- maintaining structural consistency  
- producing deterministic transformations  
- respecting layer boundaries  

Copilot is **not** responsible for:

- deciding meaning  
- inventing structure  
- adding ideas  
- optimizing the loop  
- managing the workflow  

Those are human responsibilities.

---

## 5. What “Quick Education” Means

“Quick education” does not mean training Copilot.  
It means **establishing the stance**.

A correct quick‑education sequence is:

1. Provide the local context.  
2. Declare the layer.  
3. Declare the task.  
4. Declare the constraints.  
5. Ask Copilot to align to the HCMD Hut.

Example:

> “This is part of the PSC.  
> Align to the HCMD Hut stance.  
> Rewrite structurally.  
> No narrative.  
> No implementation.”

This is not teaching.  
This is **stance alignment**.

---

## 6. When Copilot Drifts

Signs of drift:

- narrative tone  
- implementation leaking into STS  
- structure leaking into meaning  
- speculative suggestions  
- “helpful” additions  
- loss of determinism  

When drift occurs:

1. Stop.  
2. Realign the hut.  
3. Restate the layer.  
4. Restate the task.  
5. Continue.

Drift is normal.  
Correction is mechanical.

---

## 7. What This Document Is Not

This document is **not**:

- a prompt template  
- a training guide  
- a behavioral override  
- a meta‑prompt  
- a system instruction  

It is a **reference** for how to work with Copilot inside HCMD.

---

## 8. Summary

- Copilot does not learn; it aligns.  
- The HCMD Hut defines the stance.  
- Context discipline defines stability.  
- Drift is corrected by realignment.  
- HCMD is performed, not configured.  

This is the minimal quick‑education model for HCMD.
