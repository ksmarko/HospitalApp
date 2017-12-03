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
using Logic;
using Logic.Entities;

namespace LAP.UI
{
    /// <summary>
    /// Логика взаимодействия для DoctorsPage.xaml
    /// </summary>
    public partial class DoctorsPage : Page
    {
        public static DoctorsPage instance;
        public  List<DoctorL> docs;

        public DoctorsPage()
        {
            InitializeComponent();
            grdDoctors.ItemsSource = docs;
            instance = this;
        }

        public void RefreshData(object sender, DependencyPropertyChangedEventArgs e)
        {
           docs = DoctorRegistry.GetDoctorList(); 
        }
    }
}
