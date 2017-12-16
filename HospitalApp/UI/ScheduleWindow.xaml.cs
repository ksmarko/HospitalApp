using BLL.DTO;
using BLL.Services;
using BLL.Utilits;
using HospitalApp.Views;
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
            dpDate.DisplayDateStart = DateTime.Today.AddDays(1);

            DoctorRegistry doctorRegistry = new DoctorRegistry();
            foreach (var el in doctorRegistry.GetAll())
                cboxDocsList.Items.Add(el);

            for (int i = 8; i < 20; i++)
            {
                cboxStartHours.Items.Add(i + ":00");
                cboxEndHours.Items.Add(i + ":00");
            }
        }

        private void Addshedule(object sender, RoutedEventArgs e)
        {
            TimeManager tm = new TimeManager();

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

            if (dpDate.SelectedDate == null)
            {
                MessageBox.Show("Please select date");
                return;
            }

            DoctorDTO doctor = cboxDocsList.SelectedValue as DoctorDTO;

            var schedule = ModelCreator.CreateSchedule(doctor.Id,
                dpDate.SelectedDate.Value,
                string.Join(" - ", cboxStartHours.SelectedItem.ToString(), cboxEndHours.SelectedItem.ToString()));

            var docschedule = tm.GetByDoctor(doctor);

            //TODO: edit hell
            #region hell
            //edit this shit
            if (docschedule.Count() > 0)
                foreach (var el in docschedule)
                    if (el.Date == dpDate.SelectedDate.Value)
                    {
                        schedule.Id = el.Id;
                        try
                        {
                            tm.Edit(schedule);
                        }
                        catch (BLL.Infrastructure.ValidationException)
                        {
                            var result = MessageBox.Show("You can lost patients. Continue?", "Information", MessageBoxButton.YesNo, MessageBoxImage.Question);
                            if (result == MessageBoxResult.Yes)
                            {
                                tm.EditAnyway(schedule);
                                MessageBox.Show("Schedule edited!");
                            }
                            else return;

                        }
                        //MessageBox.Show("Schedule edited!");
                        //break;
                    }
                    else
                    {
                        tm.Add(schedule);
                        MessageBox.Show("Schedule added!");
                        break;
                    }
            else
            {
                tm.Add(schedule);
                MessageBox.Show("Schedule added!");
            }
            #endregion

            this.Close();
        }

        private void Enroll(object sender, RoutedEventArgs e)
        {
            if (cboxDocsList.SelectedIndex == -1)
            {
                MessageBox.Show("Select doctor");
                return;
            }

            if (this.dpDate.SelectedDate == null)
            {
                MessageBox.Show("Please select date");
                return;
            }

            if (cboxTime.SelectedIndex == -1)
            {
                MessageBox.Show("Select time");
                return;
            }

            TimeManager tm = new TimeManager();
            DoctorDTO doctor = cboxDocsList.SelectedValue as DoctorDTO;
            var date = dpDate.SelectedDate.Value;

            var schedule = ModelCreator.CreateEnroll(doctor.Id, (PatientsPage.instance.lstPatients.SelectedValue as PatientDTO).Id,
                date, cboxTime.SelectedItem.ToString());

            tm.Add(schedule);

            MessageBox.Show("Enroll");
            this.Close();
        }

        private void UpdateTime(DoctorDTO doctor, DateTime date)
        {
            //добавление в комбобокс значений из диапазона графика
            try
            {
                cboxTime.ItemsSource = null;
                cboxTime.Items.Clear();

                List<string> timeVariants = new List<string>();

                string time = MainPage.GetDoctorShedules(doctor, date).FirstOrDefault().Time;
                char[] arr = new char[] { ' ', '-', ' ' };

                string[] tStart = time.Split(arr, StringSplitOptions.RemoveEmptyEntries);

                //ошибка обрезания
                int start = Convert.ToInt32(tStart[0].Substring(0, tStart[0].Length - 3));
                int end = Convert.ToInt32(tStart[1].Substring(0, tStart[1].Length - 3));

                for (int i = start; i < end; i++)
                {
                    timeVariants.Add(i + ":00");
                    timeVariants.Add(i + ":30");
                }

                TimeManager tm = new TimeManager();
                
                foreach (var el in tm.GetByDoctor(doctor)) //возвращает все записи врача
                {
                    timeVariants.RemoveAll(x => x == el.Time);
                }

                cboxTime.ItemsSource = timeVariants;
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Null ref in UpdateTime");
                return;
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Error with substrings");
                return;
            }
        }

        //date changed
        private void UpdateTime(object sender, SelectionChangedEventArgs e)
        {
            if (this.Title == "Enroll")
            {
                DoctorDTO doctor = cboxDocsList.SelectedValue as DoctorDTO;
                var date = dpDate.SelectedDate.Value;

                UpdateTime(doctor, date);
            }
            else return;
        }
    }
}
