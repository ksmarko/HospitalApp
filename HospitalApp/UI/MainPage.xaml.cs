using BLL.DTO;
using BLL.Services;
using HospitalApp.Utilits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HospitalApp.UI
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        TimeManager tm;
        public MainPage()
        {
            InitializeComponent();
            tm = new TimeManager();
        }

        private void Selected(int pos)
        {
            grdSelectedMenuItem.Margin = new Thickness(0, pos * 60, 0, 0);
        }

        private void MenuNavigation(object sender, SelectionChangedEventArgs e)
        {
            switch (lstMenu.SelectedIndex)
            {
                case 0: ShowHomeUI(null, null); Selected(0); break;
                case 1: ShowHomeUI(null, null); ShowDoctorsUI(null, null); Selected(1); break;
                case 2: ShowHomeUI(null, null); ShowPatientsUI(null, null); Selected(2); break;
                case 3: ShowHomeUI(null, null); ShowSettingsUI(null, null); Selected(3); break;
            }
        }

        #region Pages

        private void ShowDoctorsUI(object sender, RoutedEventArgs e)
        {
            DoctorsPageUI.IsEnabled = true;
            DoctorsPageUI.Visibility = Visibility.Visible;

            PatientsPageUI.IsEnabled = false;
            PatientsPageUI.Visibility = Visibility.Hidden;

            SettingsPageUI.IsEnabled = false;
            SettingsPageUI.Visibility = Visibility.Hidden;
        }

        private void ShowHomeUI(object sender, RoutedEventArgs e)
        {
            DoctorsPageUI.IsEnabled = false;
            DoctorsPageUI.Visibility = Visibility.Hidden;

            PatientsPageUI.IsEnabled = false;
            PatientsPageUI.Visibility = Visibility.Hidden;

            SettingsPageUI.IsEnabled = false;
            SettingsPageUI.Visibility = Visibility.Hidden;
        }

        private void ShowPatientsUI(object sender, RoutedEventArgs e)
        {
            DoctorsPageUI.IsEnabled = false;
            DoctorsPageUI.Visibility = Visibility.Hidden;

            PatientsPageUI.IsEnabled = true;
            PatientsPageUI.Visibility = Visibility.Visible;

            SettingsPageUI.IsEnabled = false;
            SettingsPageUI.Visibility = Visibility.Hidden;
        }

        private void ShowSettingsUI(object sender, RoutedEventArgs e)
        {
            DoctorsPageUI.IsEnabled = false;
            DoctorsPageUI.Visibility = Visibility.Hidden;

            PatientsPageUI.IsEnabled = false;
            PatientsPageUI.Visibility = Visibility.Hidden;

            SettingsPageUI.IsEnabled = true;
            SettingsPageUI.Visibility = Visibility.Visible;
        }

        #endregion

        private void LoadData(object sender, RoutedEventArgs e)
        { 
            List<ScheduleView> list = new List<ScheduleView>();

            foreach (var el in tm.GetAll())
                list.Add(ScheduleView.CreateRecordView(el));

            grdSchedule.ItemsSource = null;
            grdSchedule.ItemsSource = list;
        }

        private void addSchedule(object sender, RoutedEventArgs e)
        {
            ScheduleWindow wi = new ScheduleWindow();
            wi.ShowDialog();

            LoadData(null, null);
        }

        private void VisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            List<ScheduleView> list = new List<ScheduleView>();

            foreach (var el in tm.GetAll())
                list.Add(ScheduleView.CreateRecordView(el));

            grdSchedule.ItemsSource = null;
            grdSchedule.ItemsSource = list;
        }
    }
}
