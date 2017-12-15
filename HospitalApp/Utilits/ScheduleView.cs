using BLL.DTO;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApp.Utilits
{
    public class ScheduleView
    {
        public string Doctor { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }

        public static ScheduleView CreateScheduleView(ScheduleDTO scheduleDTO)
        {
            DoctorRegistry registry = new DoctorRegistry();
            var doc = registry.Find(scheduleDTO.Doctor).ToString();

            ScheduleView scheduleView = new ScheduleView()
            {
                Doctor = doc,
                Date = scheduleDTO.Date.ToShortDateString(),
                Time = scheduleDTO.Time
            };

            return scheduleView;
        }
    }
}
