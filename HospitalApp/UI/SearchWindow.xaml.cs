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
using System.Windows.Shapes;

namespace HospitalApp.UI
{
    /// <summary>
    /// Логика взаимодействия для SearchWindow.xaml
    /// </summary>
    public partial class SearchWindow : Window
    {
        DoctorRegistry registry;
        PatientRegistry patientRegistry;
        public SearchWindow()
        {
            InitializeComponent();
            registry = new DoctorRegistry();
            patientRegistry = new PatientRegistry();
        }

        //todo: flexible search
        private void FindDoctor(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text.Trim()) || string.IsNullOrEmpty(txtSurname.Text.Trim()))
            {
                MessageBox.Show("Enter data");
                return;
            }

            DoctorsPage.instance.grdDoctors.ItemsSource = null;
            DoctorsPage.instance.grdDoctors.ItemsSource = registry.Find(txtName.Text.Trim(), txtSurname.Text.Trim());

            this.Close();
        }
        
        private void FindPatient(object sender, RoutedEventArgs e)
        {
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
