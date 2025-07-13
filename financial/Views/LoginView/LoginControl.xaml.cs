using System.Windows;
using System.Windows.Controls;
using financial.Services;
using financial.Validators.FieldValidators;

namespace financial.Views.LoginView
{
    public partial class LoginControl : UserControl
    {
        string userId = "";
        public LoginControl()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            var result = AccountValidator.ValidateLogin(EmailBox.Text, PasswordBox.Password);

            if (result.isValid)
            {
                (bool, string) loginAndId = AccountManager.CheckLogin(EmailBox.Text, PasswordBox.Password);

                if (loginAndId.Item1)
                {
                    userId = loginAndId.Item2 as string;
                    MessageBox.Show("logged in successfully");
                }
                else
                {
                    MessageBox.Show("Wrong email/password!");
                    PasswordBox.Password = "";
                }
            }
            else
            {
                MessageBox.Show(result.ErrorMessage, "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CreateAccountLink_Click(object sender, RoutedEventArgs e)
        {
            if (Application.Current.MainWindow is MainWindow main)
            {
                main.LoadCreateAccount();
            }
        }
    }
}
