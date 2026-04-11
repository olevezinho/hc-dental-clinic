using Bunit;
using NUnit.Framework;
using HcDentalClinic.Layout;
using Microsoft.AspNetCore.Components;

namespace HcDentalClinic.Tests;

[TestFixture]
public class CustomLayoutTests : BunitTestContext
{
    [Test]
    public void CustomLayout_RendersBody()
    {
        var cut = Context.RenderComponent<CustomLayout>(parameters => parameters
            .Add(p => p.Body, builder => builder.AddContent(0, "custom body content")));

        Assert.That(cut.Markup, Does.Contain("custom body content"));
    }

    [Test]
    public void CustomLayout_WrapsBodyInErrorBoundary()
    {
        var cut = Context.RenderComponent<CustomLayout>(parameters => parameters
            .Add(p => p.Body, builder => builder.AddContent(0, "body")));

        Assert.That(cut.FindComponent<Microsoft.AspNetCore.Components.Web.ErrorBoundary>(), Is.Not.Null);
    }
}
