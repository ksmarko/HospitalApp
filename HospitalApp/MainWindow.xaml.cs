using MahApps.Metro.Controls;
using System.Windows;

namespace HospitalApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public static MainWindow instance;
        public MainWindow()
        {
            InitializeComponent();
            instance = this;
        }

        public void ShowLoginPageUI(object sender, RoutedEventArgs e)
        {
            LoginPageUI.IsEnabled = true;
            LoginPageUI.Visibility = Visibility.Visible;

            MainPageUI.IsEnabled = false;
            MainPageUI.Visibility = Visibility.Hidden;
        }

        public void ShowMainPageUI(object sender, RoutedEventArgs e)
        {
            MainPageUI.IsEnabled = true;
            MainPageUI.Visibility = Visibility.Visible;

            LoginPageUI.IsEnabled = false;
            LoginPageUI.Visibility = Visibility.Hidden;
        }

        private void LogOutMethod(object sender, RoutedEventArgs e)
        {
            ShowLoginPageUI(sender, e);
        }
    }
}
