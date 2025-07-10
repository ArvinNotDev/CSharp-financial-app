using financial.Services;
using financial.Validators.FieldValidators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace financial.Validators.DbValidators
{
    internal static class EmailUniqueValidator
    {
        public static ValidationResult Validate(string email)
        {
            if (AccountManager.EmailExists(email))
                return ValidationResult.Fail(ValidationMessages.EmailAlreadyExists);

            return ValidationResult.Success();
        }
    }
}
