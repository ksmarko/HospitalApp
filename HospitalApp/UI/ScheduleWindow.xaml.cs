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
    /// Логика взаимодействия для ScheduleWindow.xaml
    /// </summary>
    public partial class ScheduleWindow : Window
    {
        public ScheduleWindow()
        {
            InitializeComponent();
        }

        private void LoadData(object sender, RoutedEventArgs e)
        {
            for (int i = 8; i < 19; i++)
            {
                cboxStartHours.Items.Add(i + ":00");
                cboxEndHours.Items.Add(i + ":00");
            }

            DoctorRegistry registry = new DoctorRegistry();
            cboxDocsList.ItemsSource = registry.GetAll();
        }

        private void Addshedule(object sender, RoutedEventArgs e)
        {
            TimeManager tm = new TimeManager();

            //tm.Add(ModelCreator.CreateSchedule(cboxDocsList.SelectedValue as DoctorDTO, calendar.SelectedDate.Value, string.Join(" - ", cboxStartHours.SelectedItem.ToString(), cboxEndHours.SelectedItem.ToString())));

            ScheduleDTO schedule = new ScheduleDTO()
            {
                DoctorId = (cboxDocsList.SelectedValue as DoctorDTO).Id,
                Date = calendar.SelectedDate.Value,
                Time = string.Join(" - ", cboxStartHours.SelectedItem.ToString(), cboxEndHours.SelectedItem.ToString())
            };

            tm.Add(schedule);

            this.Close();
        }
    }
}
