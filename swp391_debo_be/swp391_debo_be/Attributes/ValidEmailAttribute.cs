using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace swp391_debo_be.Attributes
{
    public class ValidEmailAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return new ValidationResult("Email address is required.");
            }

            var email = value.ToString();
            var emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");

            if (!emailRegex.IsMatch(email))
            {
                return new ValidationResult("Email address is not valid.");
            }

            return ValidationResult.Success;
        }
    }
}
