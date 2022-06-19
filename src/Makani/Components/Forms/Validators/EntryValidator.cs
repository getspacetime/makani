using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Makani.Components.Forms.Validators;

public abstract class EntryValidator : IEntryValidator
{
    protected ValidationResult? Valid;
    protected string? Input;

    public ValidationResult IsValid(string? input)
    {
        if (Valid != null && input == Input)
        {
            return Valid;
        }

        return Validate(input);
    }

    public ValidationResult Validate(string? input)
    {
        Input = input;
        Valid = ExecuteValidate(input);

        return Valid;
    }

    public abstract ValidationResult ExecuteValidate(string? input);
}