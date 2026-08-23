# **01 — Why Two Copilots Exist**

Act I used two different copilots without explaining why.  
Act II begins by making that separation explicit.

HCMD requires two engines because **meaning and execution are different cognitive domains**.  
They cannot be handled by the same system without collapsing the structure of the loop.

A single assistant tries to interpret meaning and generate implementation at the same time.  
This mixes ambiguity with determinism, intention with mechanics, and human goals with machine execution.  
The result is drift, inconsistency, and non‑reproducible code.

The Two‑Copilot Model prevents this collapse.

- **Copilot App** handles meaning.  
  It interprets the human goal, resolves ambiguity, and produces the STS.

- **GitHub Copilot** handles execution.  
  It derives the PSC and generates deterministic implementation.

The separation is not a convenience.  
It is the structural requirement that makes HCMD possible.

Two copilots exist because **co‑intelligence only works when meaning and execution are kept apart**.