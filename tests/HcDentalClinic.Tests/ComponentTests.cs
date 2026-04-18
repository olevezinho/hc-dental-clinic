using Bunit;
using HcDentalClinic;
using HcDentalClinic.Layout;
using HcDentalClinic.Pages;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;

namespace HcDentalClinic.Tests;

[TestFixture]
public class ComponentTests
{
    private BunitContext _bunitContext = null!;

    [SetUp]
    public void Setup()
    {
        _bunitContext = new BunitContext();
        _bunitContext.JSInterop.Mode = JSRuntimeMode.Loose;
    }

    [TearDown]
    public void Cleanup()
    {
        _bunitContext.Dispose();
    }

    [Test]
    public void NavMenu_StartsCollapsed()
    {
        var cut = _bunitContext.Render<NavMenu>();

        var navContainer = cut.Find("div.nav-scrollable");

        Assert.That(navContainer.ClassList.Contains("collapse"), Is.True);
    }

    [Test]
    public void NavMenu_ToggleButton_ExpandsAndCollapsesMenu()
    {
        var cut = _bunitContext.Render<NavMenu>();

        cut.Find("button[title='Navigation menu']").Click();
        var navContainer = cut.Find("div.nav-scrollable");
        Assert.That(navContainer.ClassList.Contains("collapse"), Is.False);

        cut.Find("button[title='Navigation menu']").Click();
        navContainer = cut.Find("div.nav-scrollable");
        Assert.That(navContainer.ClassList.Contains("collapse"), Is.True);
    }

    [Test]
    public void MainLayout_RendersBodyAndNavigation()
    {
        RenderFragment body = builder => builder.AddMarkupContent(0, "<h1>Conteúdo de teste</h1>");

        var cut = _bunitContext.Render<MainLayout>(parameters => parameters.Add(layout => layout.Body, body));

        Assert.That(cut.Markup, Does.Contain("HcDentalClinic"));
        Assert.That(cut.Markup, Does.Contain("About"));
        Assert.That(cut.Find("article.content h1").TextContent, Is.EqualTo("Conteúdo de teste"));
    }

    [Test]
    public void CustomLayout_RendersBodyContent()
    {
        RenderFragment body = builder => builder.AddMarkupContent(0, "<p>Corpo do layout</p>");

        var cut = _bunitContext.Render<CustomLayout>(parameters => parameters.Add(layout => layout.Body, body));

        Assert.That(cut.Find("p").TextContent, Is.EqualTo("Corpo do layout"));
    }

    [Test]
    public void LandingPage_ShowsInitialContentWithLoadingImage()
    {
        var cut = _bunitContext.Render<LandingPage>();

        Assert.That(cut.Find("h1").TextContent, Is.EqualTo("Estamos a preparar algo especial para si."));

        var image = cut.Find("img.wip-image");
        Assert.That(image.ClassList.Contains("loading"), Is.True);
        Assert.That(image.ClassList.Contains("visible"), Is.False);

        var footerText = cut.Find("footer.wip-footer").TextContent;
        Assert.That(footerText, Does.Contain("HC Dental Clinic - Todos os direitos reservados."));
    }

    [Test]
    public void LandingPage_OnImageLoad_SetsImageAsVisible()
    {
        var cut = _bunitContext.Render<LandingPage>();

        cut.Find("img.wip-image").TriggerEvent("onload", EventArgs.Empty);

        var image = cut.Find("img.wip-image");
        Assert.That(image.ClassList.Contains("visible"), Is.True);
        Assert.That(image.ClassList.Contains("loading"), Is.False);
    }

    [Test]
    public void NotFound_ShowsExpectedMessage()
    {
        var cut = _bunitContext.Render<NotFound>();

        Assert.That(cut.Markup, Does.Contain("Não encontrado"));
        Assert.That(cut.Markup, Does.Contain("Pedimos desculpa"));
    }

    [Test]
    public void App_DefaultRoute_RendersLandingPage()
    {
        var cut = _bunitContext.Render<App>();

        Assert.That(cut.Markup, Does.Contain("Estamos a preparar algo especial para si."));
    }

    [Test]
    public void App_UnknownRoute_RendersNotFoundPage()
    {
        var cut = _bunitContext.Render<App>();

        var navigation = _bunitContext.Services.GetService<NavigationManager>();
        Assert.That(navigation, Is.Not.Null);
        navigation!.NavigateTo("/rota-invalida");

        cut.WaitForAssertion(() => Assert.That(cut.Markup, Does.Contain("Não encontrado")));
    }
}
