using System;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;

using BLL.DTO;
using BLL.Services;
using BLL.Infrastructure;

using HospitalApp.Views;

namespace HospitalApp.UI
{
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
        }

        private void ShowHomeUI(object sender, RoutedEventArgs e)
        {
            grdMain.Visibility = Visibility.Visible;
            grdMain.IsEnabled = true;

            DoctorsPageUI.IsEnabled = false;
            DoctorsPageUI.Visibility = Visibility.Hidden;

            PatientsPageUI.IsEnabled = false;
            PatientsPageUI.Visibility = Visibility.Hidden;
        }

        private void ShowPatientsUI(object sender, RoutedEventArgs e)
        {
            grdMain.Visibility = Visibility.Hidden;
            grdMain.IsEnabled = false;

            DoctorsPageUI.IsEnabled = false;
            DoctorsPageUI.Visibility = Visibility.Hidden;

            PatientsPageUI.IsEnabled = true;
            PatientsPageUI.Visibility = Visibility.Visible;
        }

        #endregion

        private void LoadData(object sender, RoutedEventArgs e)
        {
            dpDate.DisplayDateStart = DateTime.Today.AddDays(1);

            TimeManager tm = new TimeManager();
            List<ScheduleView> list = new List<ScheduleView>();

            foreach (var el in tm.GetAll())
                    list.Add(ScheduleView.CreateScheduleView(el));

            grdSchedule.ItemsSource = null;
            grdSchedule.ItemsSource = list;

            dpDate.SelectedDate = null;

            LoadDoctorsList();            
        }

        private void AddSchedule(object sender, RoutedEventArgs e)
        {
            ScheduleWindow wi = new ScheduleWindow();
            wi.Title = "Add schedule";
            wi.grdDocShedule.Visibility = Visibility.Visible;
            wi.grdEnroll.Visibility = Visibility.Collapsed;
            wi.btnAddSchedule.Visibility = Visibility.Visible;
            wi.btnEnroll.Visibility = Visibility.Hidden;
            wi.ShowDialog();
            
            ClearSearchResults(null, null);
        }

        private void LoadDoctorsList()
        {
            DoctorRegistry dr = new DoctorRegistry();

            cboxDoctorsList.Items.Clear();

            foreach (var el in dr.GetAvailable())
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
            DateTime date = dpDate.SelectedDate.Value;

            grdSchedule.ItemsSource = null;
            grdSchedule.ItemsSource = GetDoctorShedules(doctor, date);
        }

        public static List<ScheduleView> GetDoctorShedules(DoctorDTO doctor, DateTime date)
        {
            TimeManager tm = new TimeManager();
            List<ScheduleView> list = new List<ScheduleView>();

            foreach (var el in tm.GetAll())
                if (el.DoctorId == doctor.Id && el.Date == date)
                    list.Add(ScheduleView.CreateScheduleView(el));

            return list;
        }

        private void ClearSearchResults(object sender, RoutedEventArgs e)
        {
            LoadData(sender, e);
            cboxDoctorsList.SelectedIndex = -1;
            dpDate.SelectedDate = null;
        }

        private void RemoveSchedule(object sender, RoutedEventArgs e)
        {
            TimeManager tm = new TimeManager();
            var schedule = grdSchedule.SelectedValue as ScheduleView;

            try
            {
                tm.Remove(schedule.Id);
                LoadData(null, null);
            }
            catch (ValidationException)
            {
                var result = MessageBox.Show("You can lost patients. Continue?", "Information", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    tm.RemoveAnyway(schedule.Id);
                    LoadData(null, null);
                }
                else return;
            }
        }
    }
}