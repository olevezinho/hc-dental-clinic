using Microsoft.JSInterop;

namespace HcDentalClinic.Services;

public class CookieConsentService(IJSRuntime jsRuntime)
{
    private Task? _initialization;

    public event Action? Changed;
    public bool HasConsent { get; private set; }

    // All callers share the same initialization, so the JS interop runs only once
    public Task InitializeAsync() => _initialization ??= InitializeCoreAsync();

    public async Task AcceptAsync()
    {
        try
        {
            await jsRuntime.InvokeVoidAsync("setCookieConsent");
            HasConsent = true;
            Changed?.Invoke();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao gravar consentimento: {ex.Message}");
        }
    }

    private async Task InitializeCoreAsync()
    {
        try
        {
            var consent = await jsRuntime.InvokeAsync<string>("getCookieConsent");
            HasConsent = consent == "true";
        }
        catch (Exception ex)
        {
            // In case of error (e.g. prerendering), assume there is no consent
            Console.WriteLine($"Erro ao verificar cookies: {ex.Message}");
            HasConsent = false;
        }
    }
}