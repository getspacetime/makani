namespace Makani;
internal interface IFormComponent
{
    string? Value { get; set; }
    bool HasError { get; set; }
    void Validate(object? value);
}