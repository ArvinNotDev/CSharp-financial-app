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
        public void AnimateContent(UserControl newContent, bool slideFromRight = true)
        {
            newContent.Opacity = 0;

            double fromX = slideFromRight ? 80 : -80;

            var trans = new TranslateTransform(fromX, 0);
            newContent.RenderTransform = trans;

            var storyboard = new Storyboard();

            var slideAnim = new DoubleAnimation
            {
                From = fromX,
                To = 0,
                Duration = TimeSpan.FromMilliseconds(400),
                EasingFunction = new BackEase
                {
                    Amplitude = 0.4,
                    EasingMode = EasingMode.EaseOut
                }
            };
            Storyboard.SetTarget(slideAnim, newContent);
            Storyboard.SetTargetProperty(slideAnim, new PropertyPath("(UIElement.RenderTransform).(TranslateTransform.X)"));

            var fadeIn = new DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = TimeSpan.FromMilliseconds(400),
                EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseOut }
            };
            Storyboard.SetTarget(fadeIn, newContent);
            Storyboard.SetTargetProperty(fadeIn, new PropertyPath("Opacity"));

            MainContent.Content = newContent;
            storyboard.Children.Add(slideAnim);
            storyboard.Children.Add(fadeIn);
            storyboard.Begin(newContent);
        }


    }

}