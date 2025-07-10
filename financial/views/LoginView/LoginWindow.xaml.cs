using System.Windows;

namespace financial
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }
        private void CreateAccountLink_Click(object sender, RoutedEventArgs e)
        {
            CreateAccountWindow createAccountWindow = new CreateAccountWindow();
            createAccountWindow.Owner = this;
            createAccountWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            createAccountWindow.ShowDialog();
        }
    }
}