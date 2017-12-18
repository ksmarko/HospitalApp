using System;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;

using BLL.DTO;
using BLL.Services;

namespace HospitalApp.UI
{
    public partial class DoctorsPage : Page
    {
        public static DoctorsPage instance;
        public IEnumerable<DoctorDTO> docs;

        public DoctorsPage()
        {
            InitializeComponent();
            Refresh();
            instance = this;
        }

        public void RefreshData(object sender, DependencyPropertyChangedEventArgs e)
        {
            Refresh();
        }

        private void Refresh()
        {
            DoctorRegistry reg = new DoctorRegistry();
            docs = reg.GetAvailable();
            grdDoctors.ItemsSource = docs;
        }
        
        private void AddDoctor(object sender, RoutedEventArgs e)
        {
            HumanManagerWindow wi = new HumanManagerWindow();
            wi.btnAddDoc.Visibility = Visibility.Visible;
            wi.btnSaveDoc.Visibility = Visibility.Hidden;
            wi.btnAddPat.Visibility = Visibility.Hidden;
            wi.ShowDialog();
            Refresh();
        }
        
        private void RemoveDoctor(object sender, RoutedEventArgs e)
        {
            DoctorRegistry registry = new DoctorRegistry();

            try
            {
                string question = "Are you sure to remove doctor " + (grdDoctors.SelectedValue as DoctorDTO).ToString() + " ?";

                MessageBoxResult result = MessageBox.Show(question, "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    registry.Remove(grdDoctors.SelectedValue as DoctorDTO);
                    Refresh();
                }
                else return;
            }
            catch(NullReferenceException)
            {
                return;
            }
        }
        
        private void EditDoctorData(object sender, RoutedEventArgs e)
        {
            try
            {
                HumanManagerWindow wi = new HumanManagerWindow();
                wi.Title = "Edit doctor's data";
                wi.txtName.Text = (grdDoctors.SelectedValue as DoctorDTO).Name;
                wi.txtSurname.Text = (grdDoctors.SelectedValue as DoctorDTO).Surname;
                wi.txtSpec.Text = (grdDoctors.SelectedValue as DoctorDTO).Specialization;

                wi.btnAddDoc.Visibility = Visibility.Hidden;
                wi.btnSaveDoc.Visibility = Visibility.Visible;
                wi.btnAddPat.Visibility = Visibility.Hidden;

                wi.ShowDialog();
                Refresh();
            }
            catch (NullReferenceException)
            {
                return;
            }
        }

        private void FindDoctor(object sender, RoutedEventArgs e)
        {
            SearchWindow wi = new SearchWindow();
            wi.btnFindDoc.Visibility = Visibility.Visible;
            wi.btnFindPat.Visibility = Visibility.Hidden;

            wi.ShowDialog();
        }

        private void ClearSearchResults(object sender, RoutedEventArgs e)
        {
            Refresh();
        }
    }
}
