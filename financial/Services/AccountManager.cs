using financial.Models;
using System.Text.Json;
using financial.Validators;
using File = System.IO.File;
using financial.Validators.FieldValidators;
using financial.Validators.DbValidators;

namespace financial.Services
{
    internal class AccountManager
    {
        private static List<Account> accounts = new();

        private const string FilePath = "accounts.json";
        public static void LoadAccounts()
        {
            if (File.Exists(FilePath))
            {
                string json = File.ReadAllText(FilePath);
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                accounts = JsonSerializer.Deserialize<List<Account>>(json, options) ?? new List<Account>();
            }
        }

        public static void SaveAccounts()
        {
            string json = JsonSerializer.Serialize(accounts, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(FilePath, json);
        }

        public static (bool, string) AddAccount(string firstName, string lastName, string email, int birthDate, bool? gender, string password)
        {
            if (EmailExists(email))
            {
                return (false, ValidationMessages.EmailNotUnique);
            }
            var acc = new Account(firstName, lastName, email, birthDate, gender, password);
            accounts.Add(acc);
            SaveAccounts();
            return (true, "Successfully logged in");
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