using Bunit;
using NUnit.Framework;
using HcDentalClinic.Pages;

namespace HcDentalClinic.Tests;

[TestFixture]
public class NotFoundTests : BunitTestContext
{
    [Test]
    public void NotFound_RendersHeading()
    {
        var cut = Context.RenderComponent<NotFound>();

        Assert.That(cut.Find("h3").TextContent, Is.EqualTo("Não encontrado"));
    }

    [Test]
    public void NotFound_RendersParagraph()
    {
        var cut = Context.RenderComponent<NotFound>();

        Assert.That(cut.Find("p").TextContent, Does.Contain("Pedimos desculpa"));
    }
}
