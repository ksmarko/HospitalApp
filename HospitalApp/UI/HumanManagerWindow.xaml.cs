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
using System.Windows.Shapes;
using BLL.Services;
using BLL.Infrastructure;
using BLL.Interfaces;
using BLL.DTO;

namespace HospitalApp.UI
{
    /// <summary>
    /// Логика взаимодействия для AddDoctorWindow.xaml
    /// </summary>
    public partial class HumanManagerWindow : Window
    {
        DoctorRegistry registry;
        PatientRegistry patientRegistry;

        public HumanManagerWindow()
        {
            registry = new DoctorRegistry();
            patientRegistry = new PatientRegistry();
            InitializeComponent();
        }

        private void AddDoctor(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtName.Text.Trim())  && !string.IsNullOrEmpty(txtSurname.Text.Trim()) && !string.IsNullOrEmpty(txtSpec.Text.Trim()))
            {
                registry.Add(ModelCreator.CreteDoctor(txtName.Text, txtSurname.Text, txtSpec.Text));
                this.Close();
            }
            else
            {
                MessageBox.Show("Enter data", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void EditDoctorData(object sender, RoutedEventArgs e)
        {
            if (txtName.Text != "" && txtSurname.Text != "" && txtSpec.Text != "")
            {
                var doctor = ModelCreator.CreteDoctor(txtName.Text, txtSurname.Text, txtSpec.Text);
                doctor.Id = (DoctorsPage.instance.grdDoctors.SelectedValue as DoctorDTO).Id;

                registry.Edit(doctor);
                this.Close();
            }
            else
            {
                MessageBox.Show("Enter data", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void AddPatient(object sender, RoutedEventArgs e)
        {
            if (txtName.Text != "" && txtSurname.Text != "")
            {
                patientRegistry.Add(ModelCreator.CreatePatient(txtName.Text, txtSurname.Text));
                this.Close();
            }
            else
            {
                MessageBox.Show("Enter data", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }
    }
}
