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
using System.Windows.Shapes;

namespace HospitalApp.UI
{
    /// <summary>
    /// Логика взаимодействия для AddDoctorWindow.xaml
    /// </summary>
    public partial class AddDoctorWindow : Window
    {
        public AddDoctorWindow()
        {
            InitializeComponent();
        }

        private void AddDoctor(object sender, RoutedEventArgs e)
        {
            if (txtName.Text != "" && txtSurname.Text != "" && txtSpec.Text != "")
            {
                DoctorRegistry.AddDoctor(txtName.Text, txtSurname.Text, txtSpec.Text);
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
                DoctorRegistry.EditDoctorData((DoctorsPage.instance.grdDoctors.SelectedValue as DoctorL).Id, txtName.Text, txtSurname.Text, txtSpec.Text);
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
