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
        public int Id { get; set; }
        public string Doctor { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Addition { get; set; }

        public static ScheduleView CreateScheduleView(ScheduleDTO scheduleDTO)
        {
            DoctorRegistry registry = new DoctorRegistry();

            //null
            var doc = registry.Find(scheduleDTO.DoctorId);

            ScheduleView scheduleView = new ScheduleView()
            {
                Id = scheduleDTO.Id,
                Doctor = doc.Name,
                Date = scheduleDTO.Date.ToShortDateString(),
                Time = scheduleDTO.Time,
                Addition = scheduleDTO.Addition
            };

            return scheduleView;
        }
    }
}
