using HcDentalClinic;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddMudServices();

// For local development, set the minimum log level to Debug to see detailed logs in the browser console
if(builder.HostEnvironment.IsDevelopment())
{
    builder.Logging.SetMinimumLevel(LogLevel.Debug);
}

await builder.Build().RunAsync();

// Há uma mecânica de 'gamification' na clinica:
// A criança entra e recebe um bilhete que é um 'voo', como se fosse de avião mas
// é um balão de ar quente (com animais).
// Com o objetivo de se tornar numa criança com sorriso saudavel
// Vai recebendo prémios, até se tornar num 'guardião do sorriso saudável'
// 1 carimbo por consulta
// (com alguns adicionais em caso de bom comportamento)
// No final de todos os tratamentos, aí sim consegue ser um guardião do sorriso
// Recebe um certificado, uma medalha e temos um mural, onde após serem fotografados, são
// constituidos como membros do clube dos guardiões do sorriso

// Depois disso há ainda mais 2 níveis, mantendo-se
// o livro e o paciente em constante atualização e
// manutenção

// São 5 animais