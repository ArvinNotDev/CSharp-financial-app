using System.Windows;
using System.Windows.Controls;
using financial.Validators.FieldValidators;

namespace financial.Views.LoginView
{
    public partial class LoginControl : UserControl
    {
        public LoginControl()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            var result = AccountValidator.ValidateLogin(EmailBox.Text, PasswordBox.Password);

            if (result.isValid)
            {
                //logged in
                MessageBox.Show("logged in");
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
