using System.Windows;

using BLL.Services;

namespace HospitalApp.UI
{
    public partial class SearchWindow : Window
    {
        public SearchWindow()
        {
            InitializeComponent();
        }
        
        private void FindDoctor(object sender, RoutedEventArgs e)
        {
            DoctorRegistry doctorRegistry = new DoctorRegistry();

            if (string.IsNullOrEmpty(txtName.Text.Trim()) || string.IsNullOrEmpty(txtSurname.Text.Trim()))
            {
                MessageBox.Show("Enter data");
                return;
            }

            DoctorsPage.instance.grdDoctors.ItemsSource = null;
            DoctorsPage.instance.grdDoctors.ItemsSource = doctorRegistry.Find(txtName.Text.Trim(), txtSurname.Text.Trim());

            this.Close();
        }
        
        private void FindPatient(object sender, RoutedEventArgs e)
        {
            PatientRegistry patientRegistry = new PatientRegistry();

            if (string.IsNullOrEmpty(txtName.Text.Trim()) || string.IsNullOrEmpty(txtSurname.Text.Trim()))
            {
                MessageBox.Show("Enter data");
                return;
            }

            PatientsPage.instance.lstPatients.Items.Clear();
            PatientsPage.instance.lstPatients.ItemsSource = patientRegistry.Find(txtName.Text.Trim(), txtSurname.Text.Trim());
            this.Close();
        }
    }
}
