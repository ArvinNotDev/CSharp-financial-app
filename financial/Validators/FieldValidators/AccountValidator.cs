using System;
using System.Text.RegularExpressions;

namespace financial.Validators.FieldValidators
{
    internal static class AccountValidator
    {
        public static ValidationResult Validate(string firstName, string lastName, string email, DateTime? birthDate, bool? gender, string password)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                return ValidationResult.Fail(ValidationMessages.FirstNameRequired);

            if (string.IsNullOrWhiteSpace(lastName))
                return ValidationResult.Fail(ValidationMessages.LastNameRequired);

            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase))
                return ValidationResult.Fail(ValidationMessages.EmailInvalid);

            if (birthDate == null)
                return ValidationResult.Fail(ValidationMessages.BirthYearInvalid);

            if (birthDate > DateTime.Now)
                return ValidationResult.Fail(ValidationMessages.BirthYearInvalid);

            if (birthDate.Value.Year < 1900)
                return ValidationResult.Fail(ValidationMessages.BirthYearInvalid);

            if (string.IsNullOrWhiteSpace(password) || password.Length < 6)
                return ValidationResult.Fail(ValidationMessages.PasswordTooShort);

            return ValidationResult.Success();
        }
    }
}
