﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace HospitalApp.UI
{
    /// <summary>
    /// Логика взаимодействия для PatientsPage.xaml
    /// </summary>
    public partial class PatientsPage : Page
    {
        public static PatientsPage instance;
        public PatientsPage()
        {
            InitializeComponent();
            instance = this;
        }

        //list.selected index changed
        private void PartnersNavigation(object sender, SelectionChangedEventArgs e)
        {
            txtName.Text = lstPatients.SelectedItem.ToString();
            txtMail.Text = "e-mail:   " + Regex.Replace(lstPatients.SelectedItem.ToString(), " ", ".").ToLower() + "@job.ca";
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var el in PatientRegistry.GetPatientList())
                lstPatients.Items.Add(el);
        }

        private void AddPatient(object sender, RoutedEventArgs e)
        {
            AddDoctorWindow wi = new AddDoctorWindow();
            wi.Title = "Add patient";
            wi.txtSpec.Visibility = Visibility.Collapsed;
            wi.lblSpec.Visibility = Visibility.Collapsed;

            wi.btnAddDoc.Visibility = Visibility.Hidden;
            wi.btnSaveDoc.Visibility = Visibility.Hidden;
            wi.btnAddPat.Visibility = Visibility.Visible;

            wi.ShowDialog();
            RefreshPage();
        }

        private void RemovePatient(object sender, RoutedEventArgs e)
        {
            if (lstPatients.SelectedIndex != -1)
            {
                string question = "Are you sure to remove patient " + (lstPatients.SelectedValue as PatientDTO).ToString() + " ?";

                MessageBoxResult result = MessageBox.Show(question, "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    PatientRegistry.RemovePatient((lstPatients.SelectedValue as PatientDTO).Id);
                    RefreshPage();
                }
                else return;
            }
            else return;
        }

        private void PatientsNavigation(object sender, SelectionChangedEventArgs e)
        {
            if (lstPatients.SelectedIndex != -1)
            {
                txtName.Text = (lstPatients.SelectedValue as PatientDTO).ToString();
                grdCard.ItemsSource = PatientRegistry.GetAllRecords(lstPatients.SelectedValue as PatientDTO);

                grdPatientContent.Visibility = Visibility.Visible;
                grdEmptyContent.Visibility = Visibility.Hidden;
            }
            else
                grdCard.ItemsSource = null;

        }

        private void AddRecord(object sender, RoutedEventArgs e)
        {
            AddRecordWindow wi = new AddRecordWindow();
            wi.ShowDialog();

            if (lstPatients.SelectedIndex != -1)
            {
                List<RecordDTO> re = new List<RecordDTO>();
                re = PatientRegistry.GetAllRecords(lstPatients.SelectedValue as PatientDTO);

                grdCard.ItemsSource = null;
                grdCard.ItemsSource = re;
            }
        }

        //page visible changed
        private void RefreshPage(object sender, DependencyPropertyChangedEventArgs e)
        {
            RefreshPage();
        }

        private void RefreshPage()
        {
            lstPatients.Items.Clear();

            foreach (var el in PatientRegistry.GetPatientList())
                lstPatients.Items.Add(el);

            grdCard.ItemsSource = null;

            grdPatientContent.Visibility = Visibility.Hidden;
            grdEmptyContent.Visibility = Visibility.Visible;
        }

        private void FindPatient(object sender, RoutedEventArgs e)
        {
            SearchWindow wi = new SearchWindow();
            wi.btnFindDoc.Visibility = Visibility.Hidden;
            wi.btnFindPat.Visibility = Visibility.Visible;
            wi.txtSpec.Visibility = Visibility.Collapsed;
            wi.lblSpec.Visibility = Visibility.Collapsed;
            
            wi.ShowDialog();
        }
    }
}