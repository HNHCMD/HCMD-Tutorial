# Appendix H — How to Align Copilot’s Hut in Word

When working in long documents, Copilot sometimes drifts out of the correct
reasoning mode. For HCMD work, the correct mode is the **HCMD Hut**, defined in:
    huts/shop/

This appendix explains how to realign Copilot’s hut inside Microsoft Word so
that the assistant returns to the correct stance.

---

## Why Alignment Matters

The HCMD Hut enforces the cognitive constraints required for the discipline:

- meaning and structure must remain separate  
- the STS must remain implementation‑free  
- the PSC must remain declarative  
- determinism must be preserved  
- no agentic drift is allowed  

When Copilot drifts into a general‑purpose writing hut, the output becomes:

- less structured  
- less deterministic  
- more narrative than architectural  
- more prone to mixing layers  

Realignment restores the correct stance.

---

## When You Need to Realign

You should realign Copilot’s hut when you notice:

- Copilot begins rewriting HCMD text as prose  
- PSC descriptions become narrative or conversational  
- STS steps become implementation‑colored  
- the assistant starts “helpfully” adding ideas you did not ask for  
- the tone becomes soft, literary, or speculative  

These are signs that Copilot has slipped out of the HCMD Hut.

---

## How to Realign the Hut in Word

To realign Copilot’s hut:

1. **Select the relevant section** of your document  
   (e.g., the STS, PSC, or conceptual explanation).

2. **Ask Copilot explicitly** to “align to the HCMD Hut stance.”  
   This resets the reasoning mode.

3. **Provide the local context**  
   (e.g., “This is part of the PSC,” or “This is an STS refinement.”)

4. **Confirm the stance**  
   by checking that Copilot’s next response is structural, not narrative.

5. **Continue editing** once the stance is stable.

This process does not modify your document.  
It modifies Copilot’s **reasoning stance**.

---

## What Alignment Does *Not* Do

Alignment does **not**:

- change your document  
- rewrite your content  
- alter the HCMD loop  
- introduce new ideas  
- modify the PSC or STS  

It only ensures that Copilot is thinking in the correct mode.

---

## Summary

- The HCMD Hut defines the stance for all HCMD work.  
- It is located in `huts/shop/`.  
- Word sometimes causes Copilot to drift into a different hut.  
- Alignment restores the correct reasoning mode.  
- Alignment is a stance correction, not a content change.

Keeping Copilot aligned ensures that HCMD documents remain stable,
deterministic, and structurally coherent.
