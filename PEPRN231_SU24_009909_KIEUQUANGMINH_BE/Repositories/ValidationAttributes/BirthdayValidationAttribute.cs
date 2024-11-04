using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.ValidationAttributes
{
    public class BirthdayValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateTime dateValue && dateValue >= DateTime.Parse("2007-01-01"))
            {
                return new ValidationResult("Value for birthday < 01-01-2007");
            }
            return ValidationResult.Success;
        }
    }
}
