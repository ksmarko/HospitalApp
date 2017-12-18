using System.Windows;

using BLL.DTO;
using BLL.Services;
using BLL.Infrastructure;

namespace HospitalApp.UI
{
    public partial class HumanManagerWindow : Window
    {
        DoctorRegistry doctorRegistry;
        PatientRegistry patientRegistry;

        public HumanManagerWindow()
        {
            doctorRegistry = new DoctorRegistry();
            patientRegistry = new PatientRegistry();
            InitializeComponent();
        }

        private void AddDoctor(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtName.Text.Trim())  && !string.IsNullOrEmpty(txtSurname.Text.Trim()) && !string.IsNullOrEmpty(txtSpec.Text.Trim()))
            {
                doctorRegistry.Add(ModelCreator.CreteDoctor(txtName.Text, txtSurname.Text, txtSpec.Text));
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
            if (!string.IsNullOrEmpty(txtName.Text.Trim()) && !string.IsNullOrEmpty(txtSurname.Text.Trim()) && !string.IsNullOrEmpty(txtSpec.Text.Trim()))
            {
                var doctor = ModelCreator.CreteDoctor(txtName.Text, txtSurname.Text, txtSpec.Text);
                doctor.Id = (DoctorsPage.instance.grdDoctors.SelectedValue as DoctorDTO).Id;

                doctorRegistry.Edit(doctor);
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
            if (!string.IsNullOrEmpty(txtName.Text.Trim()) && !string.IsNullOrEmpty(txtSurname.Text.Trim()))
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
