using Bunit;
using NUnit.Framework;
using HcDentalClinic.Pages;

namespace HcDentalClinic.Tests;

[TestFixture]
public class LandingPageTests : BunitTestContext
{
    [Test]
    public void LandingPage_RendersWipContainer()
    {
        var cut = Context.RenderComponent<LandingPage>();

        Assert.That(cut.Find(".wip-container"), Is.Not.Null);
    }

    [Test]
    public void LandingPage_RendersWipText()
    {
        var cut = Context.RenderComponent<LandingPage>();

        Assert.That(cut.Find(".wip-text").TextContent, Is.EqualTo("Estamos a preparar algo especial para si."));
    }

    [Test]
    public void LandingPage_RendersFooterWithCurrentYear()
    {
        var cut = Context.RenderComponent<LandingPage>();

        var footer = cut.Find(".wip-footer");
        Assert.That(footer.TextContent, Does.Contain(DateTime.Now.Year.ToString()));
        Assert.That(footer.TextContent, Does.Contain("HC Dental Clinic"));
    }

    [Test]
    public void LandingPage_RendersWipImage()
    {
        var cut = Context.RenderComponent<LandingPage>();

        var img = cut.Find(".wip-image");
        Assert.That(img.GetAttribute("src"), Is.EqualTo("/images/background-shadowed.png"));
        Assert.That(img.GetAttribute("alt"), Is.EqualTo("Work in progress"));
    }

    [Test]
    public void LandingPage_ImageInitiallyHasLoadingClass()
    {
        var cut = Context.RenderComponent<LandingPage>();

        var img = cut.Find(".wip-image");
        Assert.That(img.ClassList, Does.Contain("loading"));
    }

    [Test]
    public void LandingPage_ImageBecomesVisibleAfterLoad()
    {
        var cut = Context.RenderComponent<LandingPage>();

        cut.Find(".wip-image").TriggerEvent("onload", new Microsoft.AspNetCore.Components.Web.ProgressEventArgs());

        var img = cut.Find(".wip-image");
        Assert.That(img.ClassList, Does.Contain("visible"));
    }
}
