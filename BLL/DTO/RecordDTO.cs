namespace BLL.DTO
{
    public class RecordDTO
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public string Date { get; set; }
        public string Diagnosis { get; set; }
        public string Therapy { get; set; }
        public string Addition { get; set; }
    }
}
