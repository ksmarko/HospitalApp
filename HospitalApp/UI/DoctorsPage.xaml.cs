using Logic;
using Logic.Entities;
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
    /*
    todo:
    1. убрать с grdDoctors колонку с индексом
    */

    public partial class DoctorsPage : Page
    {
        public static DoctorsPage instance;
        public List<DoctorDTO> docs = DoctorRegistry.GetDoctorList();

        public DoctorsPage()
        {
            InitializeComponent();
            grdDoctors.ItemsSource = docs;
            instance = this;
        }

        public void RefreshData(object sender, DependencyPropertyChangedEventArgs e)
        {
            Refresh();
        }

        private void Refresh()
        {
            docs = DoctorRegistry.GetDoctorList();
            grdDoctors.ItemsSource = docs;
        }
        
        private void AddDoctor(object sender, RoutedEventArgs e)
        {
            AddDoctorWindow wi = new AddDoctorWindow();
            wi.btnAddDoc.Visibility = Visibility.Visible;
            wi.btnSaveDoc.Visibility = Visibility.Hidden;
            wi.btnAddPat.Visibility = Visibility.Hidden;
            wi.ShowDialog();
            Refresh();
        }

        private void RemoveDoctor(object sender, RoutedEventArgs e)
        {
            try
            {
                string question = "Are you sure to remove doctor " + (grdDoctors.SelectedValue as DoctorDTO).ToString() + " ?";

                MessageBoxResult result = MessageBox.Show(question, "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    DoctorRegistry.RemoveDoctor((grdDoctors.SelectedValue as DoctorDTO).Id);
                    Refresh();
                }
                else return;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void EditDoctorData(object sender, RoutedEventArgs e)
        {
            try
            {
                AddDoctorWindow wi = new AddDoctorWindow();
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
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
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

        private void ShowDoctorInfo(object sender, RoutedEventArgs e)
        {

        }
    }
}
