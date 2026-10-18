# WebAssembly

Assume:

- The application runs inside the browser.
- Initial download size matters.
- CPU usage affects UX.
- Memory allocations should be minimised.

Avoid:

- Reflection
- Large third-party packages
- Huge JSON payloads
- Blocking the UI thread

Prefer:

- Lazy loading
- Streaming where possible
- Virtualization for large lists
- Incremental rendering