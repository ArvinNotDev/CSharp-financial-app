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
            MessageBox.Show("Account creation logic goes here!");
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
