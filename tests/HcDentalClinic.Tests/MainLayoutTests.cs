using Bunit;
using NUnit.Framework;
using HcDentalClinic.Layout;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;

namespace HcDentalClinic.Tests;

[TestFixture]
public class MainLayoutTests : BunitTestContext
{
    [Test]
    public void MainLayout_RendersSidebar()
    {
        var cut = Context.RenderComponent<MainLayout>(parameters => parameters
            .Add(p => p.Body, builder => builder.AddContent(0, "test content")));

        Assert.That(cut.Find(".sidebar"), Is.Not.Null);
    }

    [Test]
    public void MainLayout_RendersNavMenu()
    {
        var cut = Context.RenderComponent<MainLayout>(parameters => parameters
            .Add(p => p.Body, builder => builder.AddContent(0, "test content")));

        Assert.That(cut.FindComponent<NavMenu>(), Is.Not.Null);
    }

    [Test]
    public void MainLayout_RendersBody()
    {
        var cut = Context.RenderComponent<MainLayout>(parameters => parameters
            .Add(p => p.Body, builder => builder.AddContent(0, "expected body")));

        Assert.That(cut.Find("article.content").TextContent, Does.Contain("expected body"));
    }

    [Test]
    public void MainLayout_RendersAboutLink()
    {
        var cut = Context.RenderComponent<MainLayout>(parameters => parameters
            .Add(p => p.Body, builder => builder.AddContent(0, string.Empty)));

        var aboutLink = cut.Find("main .top-row a");
        Assert.That(aboutLink.TextContent.Trim(), Is.EqualTo("About"));
        Assert.That(aboutLink.GetAttribute("href"), Does.Contain("learn.microsoft.com"));
    }
}
