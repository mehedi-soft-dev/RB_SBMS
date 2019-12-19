using System;
using System.ComponentModel.DataAnnotations;

public class CustomValidation
{
    public sealed class checkUniqe : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if ((string)value == "MHRR")
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Error");
            }
        }
    }
}