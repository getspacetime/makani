namespace Makani;

public class ValidationResult
{
    public ValidationResult(bool valid, string? message = null)
    {
        Valid = valid;
        Message = message;
    }

    public bool Valid { get; }
    public string? Message { get; }
}