using financial.Views.LoginView;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace financial
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadLogin();
        }

        public void LoadLogin()
        {
            AnimateContent(new LoginControl());
        }

        public void LoadCreateAccount()
        {
            AnimateContent(new CreateAccountControl());
        }

        public void LoadMainMenu()
        {
            
        }
        public void AnimateContent(UserControl newContent)
        {
            newContent.Opacity = 0;
            TranslateTransform trans = new TranslateTransform();
            newContent.RenderTransform = trans;

            var storyboard = new Storyboard();

            var slideAnim = new DoubleAnimation(50, 0, TimeSpan.FromMilliseconds(300))
            {
                EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseOut }
            };
            Storyboard.SetTarget(slideAnim, newContent);
            Storyboard.SetTargetProperty(slideAnim, new PropertyPath("(UIElement.RenderTransform).(TranslateTransform.X)"));

            var fadeAnim = new DoubleAnimation(0, 1, TimeSpan.FromMilliseconds(300));
            Storyboard.SetTarget(fadeAnim, newContent);
            Storyboard.SetTargetProperty(fadeAnim, new PropertyPath("Opacity"));

            storyboard.Children.Add(slideAnim);
            storyboard.Children.Add(fadeAnim);

            MainContent.Content = newContent;
            storyboard.Begin(newContent);
        }

    }

}