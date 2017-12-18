using System;

namespace BLL.DTO
{
    public class ScheduleDTO
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public string Addition { get; set; }
    }
}
