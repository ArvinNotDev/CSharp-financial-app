using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace financial.Validators
{
    internal class ValidationResult
    {
        public bool isValid { get; set; }
        public string? ErrorMessage { get; set; }

        public static ValidationResult Success()
        {
            return new ValidationResult { isValid = true };
        }
        public static ValidationResult Fail(string message) 
        {
            return new ValidationResult { ErrorMessage = message };
        }
    }
}
