namespace Makani.Components.Forms.Validators;

internal class RequiredValidator : EntryValidator
{
    public override ValidationResult ExecuteValidate(string? input)
    {
        Input = input;

        // todo: should accept numbers/other data
        // todo: should accept the field name for validation msg
        Valid = string.IsNullOrWhiteSpace(input)
            ? new ValidationResult(false, "Field is required.")
            : new ValidationResult(true);

        return Valid;
    }
}