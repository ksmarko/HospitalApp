using System.Windows;

using BLL.DTO;
using BLL.Services;
using BLL.Infrastructure;

namespace HospitalApp.UI
{
    public partial class RecordWindow : Window
    {
        PatientRegistry registry;

        public RecordWindow()
        {
            InitializeComponent();
            registry = new PatientRegistry();
        }

        private void AddRecord(object sender, RoutedEventArgs e)
        {
            if (cboxDocsList.SelectedIndex == -1)
            {
                MessageBox.Show("Please select doctor");
                return;
            }

            if (string.IsNullOrEmpty(txtTher.Text.Trim()) || string.IsNullOrEmpty(txtDiag.Text.Trim()))
            {
                MessageBox.Show("PLease enter data");
                return;
            }

            registry.AddRecord(ModelCreator.CreateRecord(PatientsPage.instance.lstPatients.SelectedValue as PatientDTO, cboxDocsList.SelectedValue as DoctorDTO, txtDiag.Text, txtTher.Text, txtAdd.Text));
            MessageBox.Show("Record added!");
            this.Close();
        }

        private void LoadData(object sender, RoutedEventArgs e)
        {
            DoctorRegistry doctorRegistry = new DoctorRegistry();

            foreach (var el in doctorRegistry.GetAvailable())
                cboxDocsList.Items.Add(el);
        }
    }
}
