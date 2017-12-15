using BLL.DTO;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApp.Utilits
{
    public class EnrollView
    {
        public string Doctor { get; set; }
        public string Patient { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }

        public static EnrollView CreateEnrollView(ScheduleDTO scheduleDTO)
        {
            DoctorRegistry registry = new DoctorRegistry();
            var doc = registry.Find(scheduleDTO.Doctor).ToString();

            PatientRegistry patientRegistry = new PatientRegistry();
            var pat = patientRegistry.Find(scheduleDTO.PatientId).ToString();

            EnrollView enrollView = new EnrollView()
            {
                Doctor = doc,
                Patient = pat,
                Date = scheduleDTO.Date.ToShortDateString(),
                Time = scheduleDTO.Time
            };

            return enrollView;
        }
    }
}
