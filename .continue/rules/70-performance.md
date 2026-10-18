# Performance

Prefer:

- Span<T> when appropriate.
- ValueTask where beneficial.
- ArrayPool when allocations are significant.
- Immutable collections only when needed.

Avoid:

- LINQ inside hot loops.
- Multiple enumerations.
- Boxing.
- Unnecessary allocations.