using financial.Validators.FieldValidators;
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
            var result = AccountValidator.Validate(FirstNameBox.Text, LastNameBox.Text, EmailBox.Text, birthDate, PasswordBox.Password);
            if (result.isValid)
            {
                //create account
                MessageBox.Show("Account created successfully!");
            }
            else
            {
                MessageBox.Show(result.ErrorMessage, "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
