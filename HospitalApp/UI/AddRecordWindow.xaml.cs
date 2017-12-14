using BLL.DTO;
using BLL.Services;
using BLL.Utilits;
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
    /// Логика взаимодействия для AddRecordWindow.xaml
    /// </summary>
    public partial class AddRecordWindow : Window
    {
        PatientRegistry registry;

        public AddRecordWindow()
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
            foreach (var el in doctorRegistry.GetAll())
                cboxDocsList.Items.Add(el);
        }
    }
}
