using BLL.DTO;
using BLL.Services;
using HospitalApp.Utilits;
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

namespace HospitalApp.UI
{
    /// <summary>
    /// Логика взаимодействия для PatientsPage.xaml
    /// </summary>
    public partial class PatientsPage : Page
    {
        public static PatientsPage instance;
        PatientRegistry registry;

        public PatientsPage()
        {
            InitializeComponent();
            instance = this;
            registry = new PatientRegistry();
        }

        //list.selected index changed
        private void PartnersNavigation(object sender, SelectionChangedEventArgs e)
        {
            txtName.Text = lstPatients.SelectedItem.ToString();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var el in registry.GetAll())
                lstPatients.Items.Add(el);
        }

        private void RefreshCard()
        {
            List<RecordView> list = new List<RecordView>();

            foreach (var el in registry.GetRecords(lstPatients.SelectedValue as PatientDTO))
                list.Add(RecordView.CreateRecordView(el));

            grdCard.ItemsSource = null;
            grdCard.ItemsSource = list;
        }

        private void AddPatient(object sender, RoutedEventArgs e)
        {
            HumanManagerWindow wi = new HumanManagerWindow();
            wi.Title = "Add patient";
            wi.txtSpec.Visibility = Visibility.Collapsed;
            wi.lblSpec.Visibility = Visibility.Collapsed;

            wi.btnAddDoc.Visibility = Visibility.Hidden;
            wi.btnSaveDoc.Visibility = Visibility.Hidden;
            wi.btnAddPat.Visibility = Visibility.Visible;

            wi.ShowDialog();
            RefreshPage();
        }

        private void RemovePatient(object sender, RoutedEventArgs e)
        {
            if (lstPatients.SelectedIndex != -1)
            {
                string question = "Are you sure to remove patient " + (lstPatients.SelectedValue as PatientDTO).ToString() + " ?";

                MessageBoxResult result = MessageBox.Show(question, "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    registry.Remove(lstPatients.SelectedValue as PatientDTO);
                    RefreshPage();
                }
                else return;
            }
            else return;
        }

        private void PatientsNavigation(object sender, SelectionChangedEventArgs e)
        {
            if (lstPatients.SelectedIndex != -1)
            {
                txtName.Text = (lstPatients.SelectedValue as PatientDTO).ToString();
                RefreshCard();

                grdPatientContent.Visibility = Visibility.Visible;
                grdEmptyContent.Visibility = Visibility.Hidden;
            }
            else
                grdCard.ItemsSource = null;

        }

        private void AddRecord(object sender, RoutedEventArgs e)
        {
            RecordWindow wi = new RecordWindow();
            wi.ShowDialog();

            if (lstPatients.SelectedIndex != -1)
                RefreshCard();
        }

        //page visible changed
        private void RefreshPage(object sender, DependencyPropertyChangedEventArgs e)
        {
            RefreshPage();
        }

        private void RefreshPage()
        {
            lstPatients.ItemsSource = null;
            lstPatients.Items.Clear();

            foreach (var el in registry.GetAll())
                lstPatients.Items.Add(el);

            grdCard.ItemsSource = null;

            grdPatientContent.Visibility = Visibility.Hidden;
            grdEmptyContent.Visibility = Visibility.Visible;
        }

        private void FindPatient(object sender, RoutedEventArgs e)
        {
            SearchWindow wi = new SearchWindow();
            wi.btnFindDoc.Visibility = Visibility.Hidden;
            wi.btnFindPat.Visibility = Visibility.Visible;
            wi.txtSpec.Visibility = Visibility.Collapsed;
            wi.lblSpec.Visibility = Visibility.Collapsed;
            
            wi.ShowDialog();
        }

        private void Enroll(object sender, RoutedEventArgs e)
        {
            ScheduleWindow wi = new ScheduleWindow();
            wi.Title = "Enroll";
            wi.grdDocShedule.Visibility = Visibility.Collapsed;
            wi.grdEnroll.Visibility = Visibility.Visible;
            wi.btnAddSchedule.Visibility = Visibility.Hidden;
            wi.btnEnroll.Visibility = Visibility.Visible;
            wi.ShowDialog();
        }

        private void ClearSearchResults(object sender, RoutedEventArgs e)
        {
            RefreshPage();
        }
    }
}
