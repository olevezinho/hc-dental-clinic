# Blazor

Prefer:

- Components should be small.
- Move business logic into services only if needed.
- Keep Razor files focused on rendering.
- Use *.razor.css files
- Use CascadingValue sparingly.
- Prefer strongly typed parameters.
- Use @key where rendering stability matters.
- Dispose subscriptions.

When writing Blazor components:

- Keep markup clean.
- Move business logic to services.
- Keep @code blocks small.
- Prefer partial classes for large components.
- Prefer strongly typed parameters.
- Use EventCallback<T>.

Also prefer:

- MudStack
- MudGrid
- MudPaper
- MudCard

Avoid nested grids when a Stack is sufficient.

For Icons:
- Prefer Material Icons already available in MudBlazor.
- Do not introduce FontAwesome unless requested.

Blazor components should rarely exceed 500 lines.

If they grow larger:

- Extract child components.
- Extract services.
- Extract reusable logic.