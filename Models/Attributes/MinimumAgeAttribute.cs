using System;
using System.ComponentModel.DataAnnotations;

namespace Models.Attributes;

public class MinimumAgeAttribute : ValidationAttribute
{
    private readonly int _minimumAge;

    public MinimumAgeAttribute(int minimumAge)
    {
        _minimumAge = minimumAge;
    }

    protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
    {
        if (value is string dateString)
        {
            if (DateTime.TryParse(dateString, out DateTime dateOfBirth))
            {
                var age = DateTime.Today.Year - dateOfBirth.Year;
                if (DateTime.Today < dateOfBirth.AddYears(age))
                {
                    age--;
                }
                if (age < _minimumAge)
                {
                    return new ValidationResult(ErrorMessage);
                }
            }
            else
            {
                return new ValidationResult("Invalid date format.");
            }
        }

        return ValidationResult.Success;
    }
}
