using financial.Services;
using financial.Validators.FieldValidators;
using System;
using System.Windows;
using System.Windows.Controls;

namespace financial.Views.LoginView
{
    public partial class CreateAccountControl : UserControl
    {
        public CreateAccountControl()
        {
            InitializeComponent();
        }

        private void CreateAccount_Click(object sender, RoutedEventArgs e)
        {
            DateTime? birthDate = BirthDatePicker.SelectedDate;
            var result = AccountValidator.ValidateCreateAccount(
                FirstNameBox.Text,
                LastNameBox.Text,
                EmailBox.Text,
                birthDate,
                PasswordBox.Password
            );

            if (!result.isValid)
            {
                MessageBox.Show(result.ErrorMessage, "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (birthDate == null)
            {
                MessageBox.Show("Please select a valid birth date.");
                return;
            }

            bool gender = GenderBox.Text == "Male";

            var (status, message) = AccountManager.AddAccount(
                FirstNameBox.Text,
                LastNameBox.Text,
                EmailBox.Text,
                birthDate.Value,
                gender,
                PasswordBox.Password
            );

            if (status)
            {
                MessageBox.Show("Account created successfully!");
            }
            else
            {
                MessageBox.Show(message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            if (Application.Current.MainWindow is MainWindow main)
            {
                main.LoadLogin();
            }
        }
    }
}
