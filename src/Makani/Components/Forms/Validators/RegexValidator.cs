using System.Text.RegularExpressions;

namespace Makani.Components.Forms.Validators;

public class RegexValidator : EntryValidator
{
    private readonly Regex _rx;

    public RegexValidator(Regex rx)
    {
        _rx = rx;
    }

    public override ValidationResult ExecuteValidate(string? input)
    {
        if (input == null)
        {
            return new ValidationResult(true);
        }

        var match = _rx.Match(input);

        return new ValidationResult(match.Success, match.Success == false ? $"{input} does not match the regular expression" : null);
    }
}