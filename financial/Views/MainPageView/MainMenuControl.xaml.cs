using System;
using System.Windows;
using System.Windows.Controls;

namespace financial.Views.MainPageView
{
    public partial class MainMenuControl : UserControl
    {
        public event EventHandler? ProductsClicked;
        public event EventHandler? AccountsClicked;
        public event EventHandler? ReportsClicked;
        public event EventHandler? SettingsClicked;
        public event EventHandler? LogoutClicked;

        public MainMenuControl()
        {
            InitializeComponent();

            BtnProducts.Click += (s, e) => ProductsClicked?.Invoke(this, EventArgs.Empty);
            BtnAccounts.Click += (s, e) => AccountsClicked?.Invoke(this, EventArgs.Empty);
            BtnReports.Click += (s, e) => ReportsClicked?.Invoke(this, EventArgs.Empty);
            BtnSettings.Click += (s, e) => SettingsClicked?.Invoke(this, EventArgs.Empty);
            BtnLogout.Click += (s, e) => LogoutClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
