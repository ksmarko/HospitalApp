using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using Logic;
using Logic.Entities;

namespace HospitalApp.UI
{
    /// <summary>
    /// Логика взаимодействия для PatientsPage.xaml
    /// </summary>
    public partial class PatientsPage : Page
    {
        public PatientsPage()
        {
            InitializeComponent();
        }

        //list.selected index changed
        private void PartnersNavigation(object sender, SelectionChangedEventArgs e)
        {
            txtName.Text = lstPatients.SelectedItem.ToString();
            txtMail.Text = "e-mail:   " + Regex.Replace(lstPatients.SelectedItem.ToString(), " ", ".").ToLower() + "@job.ca";
        }

        private void RefreshData()
        {
            lstPatients.Items.Clear();

            foreach (var el in PatientRegistry.GetPatientList())
                lstPatients.Items.Add(el);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var el in PatientRegistry.GetPatientList())
                lstPatients.Items.Add(el);
        }

        private void AddPatient(object sender, RoutedEventArgs e)
        {
            AddDoctorWindow wi = new AddDoctorWindow();
            wi.Title = "Add patient";
            wi.txtSpec.Visibility = Visibility.Collapsed;
            wi.lblSpec.Visibility = Visibility.Collapsed;

            wi.btnAddDoc.Visibility = Visibility.Hidden;
            wi.btnSaveDoc.Visibility = Visibility.Hidden;
            wi.btnAddPat.Visibility = Visibility.Visible;

            wi.ShowDialog();
            RefreshData();
        }

        private void RemovePatient(object sender, RoutedEventArgs e)
        {
            if (lstPatients.SelectedIndex != -1)
            {
                string question = "Are you sure to remove patient " + (lstPatients.SelectedValue as PatientL).ToString() + " ?";

                MessageBoxResult result = MessageBox.Show(question, "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    PatientRegistry.RemovePatient((lstPatients.SelectedValue as PatientL).Id);
                    RefreshData();
                }
                else return;
            }
            else return;
        }

        private void PatientsNavigation(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                txtName.Text = (lstPatients.SelectedValue as PatientL).ToString();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
