using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Schedule
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        //public int PatientId { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; }
    }
}
