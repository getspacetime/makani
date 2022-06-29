namespace Makani.Components.Forms.Validators;

internal class MinMaxValidator : EntryValidator
{
    private readonly int _min;
    private readonly int? _max;

    public MinMaxValidator(int min, int? max = null)
    {
        _min = min;
        _max = max;
    }

    public override ValidationResult ExecuteValidate(string? input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            return MinFail();
        }

        if (!double.TryParse(input, out var n))
        {
            return new ValidationResult(false, "Input is not a number");
        }

        if (n < _min)
        {
            return MinFail();
        }

        return n > _max ? new ValidationResult(false, $"Number must be < {_max}") : new ValidationResult(true);
    }

    private ValidationResult MinFail()
    {
        return new ValidationResult(false, $"Number must be > {_min}");
    }
}