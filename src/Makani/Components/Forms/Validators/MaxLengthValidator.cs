namespace Makani.Components.Forms.Validators;

internal class MaxLengthValidator : EntryValidator
{
    private readonly int _maxLength;

    public MaxLengthValidator(int maxLength)
    {
        _maxLength = maxLength;
    }

    public override ValidationResult ExecuteValidate(string? input)
    {
        return input?.Length <= _maxLength
            ? new ValidationResult(true)
            : new ValidationResult(false, $"Field must be less than {_maxLength + 1} characters.");
    }
}