using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Makani.Components.Forms.Validators;

namespace Makani.Tests.Validators;
public class RegexValidatorTests
{
    private const string OnlyLetters = @"^[a-zA-Z]+$";

    [Fact]
    public void Validate_ShouldBeTrue_WhenInputIsNull()
    {
        var sut = new RegexValidator(new Regex("\\G"));
        var actual = sut.ExecuteValidate(null);
        actual.Valid.Should().BeTrue();
    }

    [Theory]
    [InlineData("test")]
    [InlineData("t")]
    public void Validate_ShouldBeTrue_WhenPatternMatches(string input)
    {
        var sut = new RegexValidator(new Regex(OnlyLetters));
        var actual = sut.ExecuteValidate(input);
        actual.Valid.Should().BeTrue();
    }

    [Theory]
    [InlineData("test123")]
    [InlineData("test ")]
    [InlineData(" test")]
    [InlineData(" ")]
    public void Validate_ShouldBeFalse_WhenPatternDoesNotMatch(string input)
    {
        var sut = new RegexValidator(new Regex(OnlyLetters));
        var actual = sut.ExecuteValidate(input);
        actual.Valid.Should().BeFalse();
    }
}
