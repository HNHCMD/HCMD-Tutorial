# HCMD Style Constraints

These constraints define the document‑style rules that may be applied when writing or refining HCMD documents.  
They are **not part of the HCMD Hut itself**.  
They are optional modules that can be activated when needed.

Style constraints govern **formatting**, not **reasoning**.

---

## Purpose

To ensure that HCMD documents remain:

- consistent  
- readable  
- structurally clear  
- renderer‑independent  
- easy to maintain over time  

These constraints apply only when explicitly activated (e.g., “HCMD Hut + Style Constraints”).

---

## Heading System

- **ATX headings only**  
  (`#`, `##`, `###`, `####`, …)

- **Setext headings are prohibited**  
  (`=====` and `-----`)

Rationale: ATX headings provide consistent rendering across Markdown engines and maintain a predictable structural hierarchy.

---

## Emphasis

- Bold (`**text**`) may be used inside headings for emphasis.  
- Italics (`*text*`) reserved for terminology, foreign words, or conceptual contrast.  
- Avoid overuse of emphasis to maintain clarity.

---

## Code Blocks

- Use fenced code blocks with triple backticks.  
- Specify language only when necessary for syntax highlighting.  
- Do not embed executable code in HCMD conceptual documents.

---

## Lists

- Use hyphens (`-`) for unordered lists.  
- Use numbers (`1.`) for ordered lists.  
- Avoid deep nesting; prefer structural clarity.

---

## Line Length and Spacing

- Keep paragraphs short for readability.  
- Insert blank lines between conceptual units.  
- Avoid trailing whitespace.

---

## Links and References

- Use relative paths for internal repository links.  
- Use backticks for file and folder names.  
- Avoid embedding private paths or private repository references.

---

## Document Identity

- Each document should begin with a clear ATX H1 heading.  
- Do not include metadata blocks unless required by a specific renderer.

---

## Activation

These constraints are applied only when invoked:

> **HCMD Hut + Style Constraints**

This preserves the purity of the Hut while enabling consistent document formatting.
