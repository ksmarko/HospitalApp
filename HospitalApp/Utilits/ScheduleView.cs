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
        //public string Patient { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }

        public static ScheduleView CreateRecordView(ScheduleDTO recordDTO)
        {
            DoctorRegistry registry = new DoctorRegistry();
            var doc = registry.Find(recordDTO.DoctorId).ToString();

            ScheduleView recordView = new ScheduleView()
            {
                Doctor = doc,
                Date = recordDTO.Date.ToShortDateString(),
                Time = recordDTO.Time
            };

            return recordView;
        }
    }
}
