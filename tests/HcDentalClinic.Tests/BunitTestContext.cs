using Bunit;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;
using NUnit.Framework;

namespace HcDentalClinic.Tests;

/// <summary>
/// Base class for BUnit tests. Creates a fresh <see cref="Bunit.TestContext"/> with
/// MudBlazor services registered before each test and disposes it after.
/// </summary>
public abstract class BunitTestContext
{
    protected Bunit.TestContext Context { get; private set; } = null!;

    [SetUp]
    public void SetUp()
    {
        Context = new Bunit.TestContext();
        Context.Services.AddMudServices();
        Context.JSInterop.Mode = JSRuntimeMode.Loose;
    }

    [TearDown]
    public void TearDown() => Context.Dispose();
}
