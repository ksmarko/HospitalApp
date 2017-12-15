﻿using BLL.DTO;
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
        public ScheduleWindow()
        {
            InitializeComponent();
        }

        private void LoadData(object sender, RoutedEventArgs e)
        {
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

            if (this.dpDate.SelectedDate == null)
            {
                MessageBox.Show("Please select date");
                return;
            }

            DoctorDTO doctor = cboxDocsList.SelectedValue as DoctorDTO;

            var schedule = ModelCreator.CreateSchedule(doctor.Id,
                dpDate.SelectedDate.Value,
                string.Join(" - ", cboxStartHours.SelectedItem.ToString(), cboxEndHours.SelectedItem.ToString()));

            var docschedule = tm.GetByDoctor(doctor);

            //edit this shit
            if (docschedule.Count() > 0)
                foreach (var el in docschedule)
                    if (el.Date == dpDate.SelectedDate.Value)
                    {
                        schedule.Id = el.Id;
                        tm.Edit(schedule);
                        MessageBox.Show("Schedule edited!");
                        break;
                    }
                    //else
                    //{
                    //    tm.Add(schedule);
                    //    MessageBox.Show("Schedule added!");
                    //    break;
                    //}
            //else
            //{
                tm.Add(schedule);
                MessageBox.Show("Schedule added!");
            //}

            this.Close();
        }

        private void Enroll(object sender, RoutedEventArgs e)
        {
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
                cboxTime.Items.Clear();

                string time = MainPage.GetDoctorShedules(doctor, date).FirstOrDefault().Time;
                char[] arr = new char[] { ' ', '-', ' ' };

                string[] tStart = time.Split(arr, StringSplitOptions.RemoveEmptyEntries);

                int start = Convert.ToInt32(tStart[0].Substring(0, tStart[0].Length - 3));
                int end = Convert.ToInt32(tStart[1].Substring(0, tStart[1].Length - 3));

                for (int i = start; i < end; i++)
                {
                    cboxTime.Items.Add(i + ":00");
                    cboxTime.Items.Add(i + ":30");
                }
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex.HelpLink);
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
