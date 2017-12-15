using BLL.DTO;
using BLL.Services;
using BLL.Utilits;
using HospitalApp.Utilits;
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
    /// Логика взаимодействия для ScheduleWindow.xaml
    /// </summary>
    public partial class ScheduleWindow : Window
    {
        TimeManager tm;

        public ScheduleWindow()
        {
            InitializeComponent();
            tm = new TimeManager();
        }

        private void LoadData(object sender, RoutedEventArgs e)
        {
            DoctorRegistry doctorRegistry = new DoctorRegistry();
            foreach (var el in doctorRegistry.GetAll())
                cboxDocsList.Items.Add(el);

            for (int i = 8; i < 19; i++)
            {
                cboxStartHours.Items.Add(i + ":00");
                cboxEndHours.Items.Add(i + ":00");
            }
        }

        private void Addshedule(object sender, RoutedEventArgs e)
        {
            if (cboxDocsList.SelectedIndex == -1)
            {
                MessageBox.Show("Please select doctor");
                return;
            }

            if (cboxStartHours.SelectedIndex == -1 || cboxEndHours.SelectedIndex == -1)
            {
                MessageBox.Show("Please select work hours");
                return;
            }

            if (this.dpDate.SelectedDate == null)
            {
                MessageBox.Show("Please select date");
                return;
            }
            
            tm.Add(ModelCreator.CreateSchedule((cboxDocsList.SelectedValue as DoctorDTO).Id, 
                dpDate.SelectedDate.Value, 
                string.Join(" - ", cboxStartHours.SelectedItem.ToString(), cboxEndHours.SelectedItem.ToString())));

            MessageBox.Show("Schedule added!");
            this.Close();
        }
    }
}
