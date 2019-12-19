using System;
using System.ComponentModel.DataAnnotations;


namespace CustomValidationinMVC.Models

{

    public class ShippedDateValidate : ValidationAttribute

    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)

        {

            DateTime CurrentDate = DateTime.Now;

            string Message = string.Empty;

            if (Convert.ToDateTime(value) < CurrentDate)

            {

                Message = "Shipped Date cannot be less than current date";

                return new ValidationResult(Message);

            }

            return ValidationResult.Success;

        }

    }

}