using System;

namespace Data.Entities
{
    public class Schedule
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public string Addition { get; set; }
    }
}
