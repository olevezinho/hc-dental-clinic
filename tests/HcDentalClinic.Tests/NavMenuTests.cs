using Bunit;
using NUnit.Framework;
using HcDentalClinic.Layout;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;

namespace HcDentalClinic.Tests;

[TestFixture]
public class NavMenuTests : BunitTestContext
{
    [Test]
    public void NavMenu_RendersNavbarBrand()
    {
        var cut = Context.RenderComponent<NavMenu>();

        Assert.That(cut.Find(".navbar-brand").TextContent, Is.EqualTo("HcDentalClinic"));
    }

    [Test]
    public void NavMenu_RendersHomeLink()
    {
        var cut = Context.RenderComponent<NavMenu>();

        var homeLink = cut.Find("a.nav-link");
        Assert.That(homeLink.TextContent.Trim(), Does.Contain("Home"));
    }

    [Test]
    public void NavMenu_HomeLinkHrefIsRoot()
    {
        var cut = Context.RenderComponent<NavMenu>();

        var homeLink = cut.Find("a.nav-link");
        Assert.That(homeLink.GetAttribute("href"), Is.EqualTo(""));
    }

    [Test]
    public void NavMenu_CollapsedByDefault()
    {
        var cut = Context.RenderComponent<NavMenu>();

        var nav = cut.Find(".nav-scrollable");
        Assert.That(nav.ClassList, Does.Contain("collapse"));
    }

    [Test]
    public void NavMenu_TogglesOnButtonClick()
    {
        var cut = Context.RenderComponent<NavMenu>();

        cut.Find("button.navbar-toggler").Click();

        var nav = cut.Find(".nav-scrollable");
        Assert.That(nav.ClassList, Does.Not.Contain("collapse"));
    }

    [Test]
    public void NavMenu_CollapsesAfterTwoClicks()
    {
        var cut = Context.RenderComponent<NavMenu>();

        cut.Find("button.navbar-toggler").Click();
        cut.Find(".nav-scrollable").Click();

        var nav = cut.Find(".nav-scrollable");
        Assert.That(nav.ClassList, Does.Contain("collapse"));
    }
}
