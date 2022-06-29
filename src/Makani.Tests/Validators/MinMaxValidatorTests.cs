using Makani.Components.Forms.Validators;

namespace Makani.Tests.Validators;

public class MinMaxValidatorTests
{
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public void Validate_ShouldBeFalse_WhenInputMissing(string? input)
    {
        var sut = new MinMaxValidator(0);
        var actual = sut.ExecuteValidate(input);
        actual.Valid.Should().BeFalse();
    }

    [Theory]
    [InlineData("1")]
    public void Validate_ShouldBeFalse_WhenBelowMin(string? input)
    {
        var sut = new MinMaxValidator(2);
        var actual = sut.ExecuteValidate(input);
        actual.Valid.Should().BeFalse();
    }

    [Theory]
    [InlineData("2")]
    [InlineData("3")]
    public void Validate_ShouldBeTrue_WhenAboveMin(string? input)
    {
        var sut = new MinMaxValidator(2);
        var actual = sut.ExecuteValidate(input);
        actual.Valid.Should().BeTrue();
    }

    [Theory]
    [InlineData("2")]
    [InlineData("3")]
    [InlineData("4")]
    public void Validate_ShouldBeTrue_WhenBelowMax(string? input)
    {
        var sut = new MinMaxValidator(2, 4);
        var actual = sut.ExecuteValidate(input);
        actual.Valid.Should().BeTrue();
    }

    [Theory]
    [InlineData("4")]
    [InlineData("5")]
    public void Validate_ShouldBeFalse_WhenAboveMax(string? input)
    {
        var sut = new MinMaxValidator(2, 3);
        var actual = sut.ExecuteValidate(input);
        actual.Valid.Should().BeFalse();
    }
}