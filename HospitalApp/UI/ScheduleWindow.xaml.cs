﻿using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;

using BLL.DTO;
using BLL.Services;
using BLL.Infrastructure;

namespace HospitalApp.UI
{
    public partial class ScheduleWindow : Window
    {
        public ScheduleWindow()
        {
            InitializeComponent();
        }

        private void LoadData(object sender, RoutedEventArgs e)
        {
            int startHours = 8;
            int endHours = 20;

            dpDate.DisplayDateStart = DateTime.Today.AddDays(1);

            DoctorRegistry doctorRegistry = new DoctorRegistry();
            foreach (var el in doctorRegistry.GetAvailable())
                cboxDocsList.Items.Add(el);

            for (int i = startHours; i < endHours; i++)
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

            if (docschedule.Count() > 0)
            {
                foreach (var el in docschedule)
                    if (el.Date == dpDate.SelectedDate.Value)
                    {
                        schedule.Id = el.Id;
                        try
                        {
                            tm.Edit(schedule);
                        }
                        catch (ValidationException)
                        {
                            var result = MessageBox.Show("You can lost patients. Continue?", "Information", MessageBoxButton.YesNo, MessageBoxImage.Question);
                            if (result == MessageBoxResult.Yes)
                            {
                                tm.EditAnyway(schedule);
                                MessageBox.Show("Schedule edited!");
                            }
                            else return;
                        }
                        break;
                    }
                    else
                    {
                        tm.Add(schedule);
                        MessageBox.Show("Schedule added!");
                        break;
                    }
            }
            else
            {
                tm.Add(schedule);
                MessageBox.Show("Schedule added!");
            }

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
            DateTime date = dpDate.SelectedDate.Value;

            var schedule = ModelCreator.CreateEnroll(doctor.Id, (PatientsPage.instance.lstPatients.SelectedValue as PatientDTO).Id,
                date, cboxTime.SelectedItem.ToString());

            tm.Add(schedule);

            MessageBox.Show("Enroll");
            this.Close();
        }

        private void UpdateTime(DoctorDTO doctor, DateTime date)
        {
            try
            {
                cboxTime.ItemsSource = null;
                cboxTime.Items.Clear();

                TimeManager tm = new TimeManager();

                string time = MainPage.GetDoctorShedules(doctor, date).FirstOrDefault().Time;
                List<string> timeVariants = tm.TimeParsing(time).ToList();
                
                foreach (var el in tm.GetByDoctor(doctor))
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
            catch (ValidationException)
            {
                Console.WriteLine("Error with substrings");
                return;
            }
        }
        
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
