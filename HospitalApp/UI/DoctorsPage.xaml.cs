using BLL.DTO;
using BLL.Services;
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
    public partial class DoctorsPage : Page
    {
        DoctorRegistry registry;
        public static DoctorsPage instance;
        public IEnumerable<DoctorDTO> docs;

        public DoctorsPage()
        {
            registry = new DoctorRegistry();
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
            docs = reg.GetAll();
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
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
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
