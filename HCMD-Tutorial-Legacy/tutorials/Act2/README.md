# **Act 2 — Architecture of the Two‑Engine Model**

Act 2 explains the architecture that makes the HCMD loop work.  
It shows why two engines exist, how they divide responsibility, and how this division produces determinism, reproducibility, and long‑term stability.

This Act is written under the **HCMD Hut**, the stance used for producing HCMD artifacts.  
The HCMD Hut and its blueprint are located in `huts/shop/`.

You do not need to understand huts to read Act 2.  
They define the stance, not the content.

---

## **What Act 2 Demonstrates**

Act 2 presents the architectural foundation of HCMD:

1. why two Copilots exist  
2. the nature of the meaning‑side engine  
3. the nature of the structure‑side engine  
4. the boundary between the engines  
5. the mapping of layers across the HCMD loop  
6. how determinism and reproducibility emerge  
7. common failure modes and how HCMD avoids them  
8. the general pattern that unifies all Acts  

Act 2 is conceptual and structural.  
It explains *why* the loop in Act 1 works.

Read it steadily.  
Let the architecture settle.

---

## **Files in This Act**

- **00 — How to Read Act 2**  
  How to approach the architectural explanations.

- **01 — Why Two Copilots Exist**  
  The necessity of separating meaning and structure.

- **02 — Meaning‑Side Engine**  
  The engine that interprets human goals.

- **03 — Structure‑Side Engine**  
  The engine that organizes work into PSC.

- **04 — Boundary Between Engines**  
  The line that keeps the system stable.

- **05 — Layer Mapping**  
  How the HCMD layers align with the two engines.

- **06 — Determinism and Reproducibility**  
  Why HCMD produces stable results across time.

- **07 — Failure Modes**  
  What goes wrong without the two‑engine model.

- **08 — General Pattern**  
  The architectural pattern that unifies all Acts.

- **09 — Summary**  
  A concise recap of the architecture.
