using System.Windows;
using System.Windows.Controls;
using financial.Views;

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
            MessageBox.Show("Login clicked.");
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
