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
        public MainPage()
        {
            InitializeComponent();
        }

        private void Selected(int pos)
        {
            grdSelectedMenuItem.Margin = new Thickness(0, pos * 60, 0, 0);
        }

        private void MenuNavigation(object sender, SelectionChangedEventArgs e)
        {
            switch (lstMenu.SelectedIndex)
            {
                case 0: ShowHomeUI(null, null); Selected(0); LoadData(null, null); break;
                case 1: ShowHomeUI(null, null); ShowDoctorsUI(null, null); Selected(1); break;
                case 2: ShowHomeUI(null, null); ShowPatientsUI(null, null); Selected(2); break;
                case 3: ShowHomeUI(null, null); ShowSettingsUI(null, null); Selected(3); break;
            }
        }

        #region Pages

        private void ShowDoctorsUI(object sender, RoutedEventArgs e)
        {
            grdMain.Visibility = Visibility.Hidden;
            grdMain.IsEnabled = false;

            DoctorsPageUI.IsEnabled = true;
            DoctorsPageUI.Visibility = Visibility.Visible;

            PatientsPageUI.IsEnabled = false;
            PatientsPageUI.Visibility = Visibility.Hidden;

            SettingsPageUI.IsEnabled = false;
            SettingsPageUI.Visibility = Visibility.Hidden;
        }

        private void ShowHomeUI(object sender, RoutedEventArgs e)
        {
            grdMain.Visibility = Visibility.Visible;
            grdMain.IsEnabled = true;

            DoctorsPageUI.IsEnabled = false;
            DoctorsPageUI.Visibility = Visibility.Hidden;

            PatientsPageUI.IsEnabled = false;
            PatientsPageUI.Visibility = Visibility.Hidden;

            SettingsPageUI.IsEnabled = false;
            SettingsPageUI.Visibility = Visibility.Hidden;
        }

        private void ShowPatientsUI(object sender, RoutedEventArgs e)
        {
            grdMain.Visibility = Visibility.Hidden;
            grdMain.IsEnabled = false;

            DoctorsPageUI.IsEnabled = false;
            DoctorsPageUI.Visibility = Visibility.Hidden;

            PatientsPageUI.IsEnabled = true;
            PatientsPageUI.Visibility = Visibility.Visible;

            SettingsPageUI.IsEnabled = false;
            SettingsPageUI.Visibility = Visibility.Hidden;
        }

        private void ShowSettingsUI(object sender, RoutedEventArgs e)
        {
            grdMain.Visibility = Visibility.Hidden;
            grdMain.IsEnabled = false;

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
            TimeManager tm = new TimeManager();
            List<ScheduleView> list = new List<ScheduleView>();

            foreach (var el in tm.GetAll())
                list.Add(ScheduleView.CreateScheduleView(el));

            grdSchedule.ItemsSource = null;
            grdSchedule.ItemsSource = list;

            LoadDoctorsList();            
        }

        private void addSchedule(object sender, RoutedEventArgs e)
        {
            ScheduleWindow wi = new ScheduleWindow();
            wi.ShowDialog();
            
            ClearSearchResults(null, null);
        }

        private void LoadDoctorsList()
        {
            DoctorRegistry dr = new DoctorRegistry();

            cboxDoctorsList.Items.Clear();

            foreach (var el in dr.GetAll())
                cboxDoctorsList.Items.Add(el);
        }

        private void FindScheduleForDoctor(object sender, RoutedEventArgs e)
        {
            if (cboxDoctorsList.SelectedIndex == -1)
            {
                MessageBox.Show("Select doctor");
                return;
            }

            if (dpDate.SelectedDate == null)
            {
                MessageBox.Show("Select date");
                return;
            }

            DoctorDTO doctor = cboxDoctorsList.SelectedValue as DoctorDTO;
            var date = dpDate.SelectedDate.Value;

            TimeManager tm = new TimeManager();
            
            List<ScheduleView> list = new List<ScheduleView>();

            foreach (var el in tm.GetAll())
            {
                if (el.Doctor == doctor.Id && el.Date == date)
                    list.Add(ScheduleView.CreateScheduleView(el));
            }

            grdSchedule.ItemsSource = null;
            grdSchedule.ItemsSource = list;
        }

        private void ClearSearchResults(object sender, RoutedEventArgs e)
        {
            LoadData(sender, e);
            cboxDoctorsList.SelectedIndex = -1;
            dpDate.SelectedDate = null;
        }
    }
}
