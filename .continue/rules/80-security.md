# Security

Never:

- Trust client-side validation.
- Store private secrets in WebAssembly but public secrets can be stored.

Always:

- Validate server-side.
- Escape user input.
- Use HTTPS.