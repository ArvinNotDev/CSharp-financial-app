using financial.Models;
using financial.Validators;
using financial.Validators.FieldValidators;
using financial.Validators.DbValidators;
using financial.JsonConverters;
using System.Text.Json;
using File = System.IO.File;

namespace financial.Services
{
    internal class AccountManager
    {
        private const string FilePath = "accounts.json";

        private static List<Account> accounts = LoadAccounts();

        public static List<Account> LoadAccounts()
        {
            if (File.Exists(FilePath))
            {
                string json = File.ReadAllText(FilePath);
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                options.Converters.Add(new DateOnlyJsonConverter());

                accounts = JsonSerializer.Deserialize<List<Account>>(json, options) ?? new List<Account>();
                return accounts;
            }
            return new List<Account>();
        }

        public static bool SaveAccounts()
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            options.Converters.Add(new DateOnlyJsonConverter());

            string json = JsonSerializer.Serialize(accounts, options);
            File.WriteAllText(FilePath, json);
            return true;
        }

        public static (bool, string) AddAccount(string firstName, string lastName, string email, DateTime birthDate, bool gender, string password)
        {
            if (EmailExists(email))
            {
                return (false, ValidationMessages.EmailNotUnique);
            }

            var acc = new Account(firstName, lastName, email, birthDate, gender, password);
            accounts.Add(acc);
            return (SaveAccounts(), "Account successfully created");
        }

        public static Account? GetAccountById(string id)
        {
            return accounts.Find(acc => acc.id == id);
        }

        public static bool DeleteAccount(string id)
        {
            Account? account = GetAccountById(id);
            if (account != null)
            {
                accounts.Remove(account);
                SaveAccounts();
                return true;
            }
            return false;
        }

        public static bool CheckPassword(string email, string inputPassword)
        {
            var user = accounts.Find(acc => acc.email == email);
            if (user == null)
                return false;

            return BCrypt.Net.BCrypt.Verify(inputPassword, user.password);
        }

        public static void PrintAccounts()
        {
            foreach (var acc in accounts)
            {
                Console.WriteLine($"{acc.firstName} {acc.lastName} - {acc.email}");
            }
        }

        public static bool EmailExists(string email)
        {
            return accounts.Exists(acc => acc.email.Equals(email, StringComparison.OrdinalIgnoreCase));
        }
    }
}
