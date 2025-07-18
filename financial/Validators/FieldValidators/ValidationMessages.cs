﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace financial.Validators.FieldValidators
{
    internal class ValidationMessages
    {
        public const string FirstNameRequired = "First name cannot be empty.";
        public const string LastNameRequired = "Last name cannot be empty.";
        public const string EmailInvalid = "Invalid email address.";
        public const string EmailNotUnique = "there is an account with given email address.";
        public const string BirthYearInvalid = "Birth year is out of valid range.";
        public const string PasswordTooShort = "Password must be at least 6 characters long.";
        public const string EmailAlreadyExists = "An account with this email already exists.";
    }
}
