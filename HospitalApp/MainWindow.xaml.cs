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

        public void ShowMainPageUI(object sender, RoutedEventArgs e)
        {
            MainPageUI.IsEnabled = true;
            MainPageUI.Visibility = Visibility.Visible;
        }

        private void MetroWindow_ContentRendered(object sender, System.EventArgs e)
        {
            ShowMainPageUI(null, null);
        }
    }
}
