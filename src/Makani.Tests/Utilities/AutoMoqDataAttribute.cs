using AutoFixture;
using AutoFixture.AutoMoq;
using Bunit;
using Microsoft.Extensions.DependencyInjection;

namespace Makani.Tests.Utilities;
public class AutoMoqDataAttribute : AutoDataAttribute
{
    public AutoMoqDataAttribute()
        : base(() => new Fixture().Customize(
            new CompositeCustomization(

                new AutoMoqCustomization(),

                // mock IElementUtils everywhere it's used
                new AddServiceCustomization<IElementUtils>()
            )))
    {
    }
}

/// <summary>
/// Integrate the test fixture with the bUnit TestContext
/// </summary>
/// <typeparam name="T"></typeparam>
public class AddServiceCustomization<T> : ICustomization where T : class
{
    public void Customize(IFixture fixture)
    {
        var mock = fixture.Freeze<Mock<T>>();

        fixture.Customize<TestContext>(ctx => ctx.Do(p => p.Services.AddSingleton(mock.Object)));
    }
}
