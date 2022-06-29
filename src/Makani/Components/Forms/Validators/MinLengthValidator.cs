namespace Makani.Components.Forms.Validators;

internal class MinLengthValidator : EntryValidator
{
    private readonly int _minLength;

    public MinLengthValidator(int minLength)
    {
        _minLength = minLength;
    }

    public override ValidationResult ExecuteValidate(string? input)
    {
        return input?.Length >= _minLength
            ? new ValidationResult(true)
            : new ValidationResult(false, $"Field must be at least {_minLength} characters.");
    }
}