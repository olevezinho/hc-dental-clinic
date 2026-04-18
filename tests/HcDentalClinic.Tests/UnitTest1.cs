using Bunit;
using HcDentalClinic.Layout;
using HcDentalClinic.Pages;

namespace HcDentalClinic.Tests;

[TestFixture]
public class ComponentTests
{
    private BunitContext _context = null!;

    [SetUp]
    public void Setup()
    {
        _context = new BunitContext();
    }

    [TearDown]
    public void Cleanup()
    {
        _context.Dispose();
    }

    [Test]
    public void NavMenu_StartsCollapsed()
    {
        var cut = _context.Render<NavMenu>();

        var navContainer = cut.Find("div.nav-scrollable");

        Assert.That(navContainer.ClassList.Contains("collapse"), Is.True);
    }

    [Test]
    public void NavMenu_ToggleButton_ExpandsMenu()
    {
        var cut = _context.Render<NavMenu>();

        cut.Find("button[title='Navigation menu']").Click();

        var navContainer = cut.Find("div.nav-scrollable");
        Assert.That(navContainer.ClassList.Contains("collapse"), Is.False);
    }

    [Test]
    public void NotFound_ShowsExpectedMessage()
    {
        var cut = _context.Render<NotFound>();

        Assert.That(cut.Markup, Does.Contain("Não encontrado"));
        Assert.That(cut.Markup, Does.Contain("Pedimos desculpa"));
    }
}
