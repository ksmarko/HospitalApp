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
        public List<DoctorL> docs = DoctorRegistry.GetDoctorList();

        public DoctorsPage()
        {
            //DoctorRegistry.ResetDB();
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
            wi.btnAdd.Visibility = Visibility.Visible;
            wi.btnSave.Visibility = Visibility.Hidden;
            wi.ShowDialog();
            Refresh();
        }

        private void RemoveDoctor(object sender, RoutedEventArgs e)
        {
            string question = "Are you sure to remove doctor " + (grdDoctors.SelectedValue as DoctorL).ToString() + " ?";

            MessageBoxResult result = MessageBox.Show(question, "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                DoctorRegistry.RemoveDoctor((grdDoctors.SelectedValue as DoctorL).Id);
                Refresh();
            }
            else return;            
        }

        private void EditDoctorData(object sender, RoutedEventArgs e)
        {
            try
            {
                AddDoctorWindow wi = new AddDoctorWindow();
                wi.Title = "Edit doctor's data";
                wi.txtName.Text = (grdDoctors.SelectedValue as DoctorL).Name;
                wi.txtSurname.Text = (grdDoctors.SelectedValue as DoctorL).Surname;
                wi.txtSpec.Text = (grdDoctors.SelectedValue as DoctorL).Specialization;
                wi.btnAdd.Visibility = Visibility.Hidden;
                wi.btnSave.Visibility = Visibility.Visible;
                wi.ShowDialog();
                Refresh();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
