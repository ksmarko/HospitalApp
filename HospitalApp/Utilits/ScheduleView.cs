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

        public ScheduleView(ScheduleDTO scheduleDTO)
        {
            DoctorRegistry registry = new DoctorRegistry();

            this.Doctor = registry.GetAll().Where(x => x.Id == 1).FirstOrDefault().ToString();
            //this.Doctor = registry.GetAll().Where(x => x.Id == scheduleDTO.DoctorId).FirstOrDefault().ToString();
            this.Date = scheduleDTO.Date.ToString();
            this.Time = scheduleDTO.Time;
        }

        public static ScheduleView CreateGeneralScheduleView(ScheduleDTO scheduleDTO)
        {
            ScheduleView scheduleView = new ScheduleView(scheduleDTO);
            return scheduleView;
        }
    }
}
