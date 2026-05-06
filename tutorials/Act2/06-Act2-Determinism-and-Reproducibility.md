# **06 — Determinism and Reproducibility**

Determinism is the measure of correctness in HCMD.  
Reproducibility is the proof that determinism has been achieved.

The Two‑Copilot Model exists to guarantee both.

When meaning and execution are separated, the loop becomes stable:

- the same STS always produces the same PSC  
- the same PSC always produces the same implementation  
- the same implementation can be regenerated at any time  

This stability is not accidental.  
It is the direct result of keeping ambiguity above the boundary and structure below it.

---

## **Why determinism matters**

Without determinism:

- the assistant improvises  
- the structure drifts  
- the code changes unpredictably  
- the human loses control  

Determinism ensures that HCMD is a discipline, not a conversation.

A deterministic loop means:

- no hidden state  
- no reinterpretation  
- no silent changes  
- no dependency on prior chat history  

The STS is the anchor that makes this possible.

---

## **Why reproducibility matters**

Reproducibility is the test that the loop is working.

If you can:

- delete the code  
- regenerate it  
- and get the same result  

then the system is stable.

If you cannot, something has contaminated the boundary:

- meaning leaked downward  
- implementation leaked upward  
- ambiguity remained unresolved  
- structure was inferred too early  

Reproducibility exposes these failures immediately.

---

## **How the Two‑Copilot Model enforces determinism**

The meaning‑side engine resolves ambiguity until the STS is complete.  
The structure‑side engine consumes the STS without reinterpretation.

This division ensures:

- meaning is clarified once  
- structure is generated consistently  
- implementation is deterministic  
- the loop is reproducible  

The engines do not share responsibilities.  
They meet only at the STS.

That is why the loop works.
