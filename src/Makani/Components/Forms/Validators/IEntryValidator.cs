namespace Makani.Components.Forms.Validators;

public interface IEntryValidator
{
    /// <summary>
    /// Checks if the entry is valid. Runs <see cref="Validate"/> if the rule
    /// has not been run, otherwise returns the cached validation result.
    /// </summary>
    /// <returns></returns>
    ValidationResult IsValid(string? input);

    /// <summary>
    /// Executes validation logic and returns the result.
    /// </summary>
    /// <returns></returns>
    ValidationResult Validate(string? input);
}