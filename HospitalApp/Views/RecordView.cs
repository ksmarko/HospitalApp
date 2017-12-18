using System.Linq;

using BLL.DTO;
using BLL.Services;

namespace HospitalApp.Views
{
    public class RecordView
    {
        public string Date { get; set; }
        public string Doctor { get; set; }
        public string Diagnosis { get; set; }
        public string Therapy { get; set; }
        public string Addition { get; set; }

        public static RecordView CreateRecordView(RecordDTO recordDTO)
        {
            DoctorRegistry registry = new DoctorRegistry();

            RecordView recordView = new RecordView()
            {
                Doctor = registry.GetAll().Where(x => x.Id == recordDTO.DoctorId ).FirstOrDefault().ToString(),
                Date = recordDTO.Date,
                Diagnosis = recordDTO.Diagnosis,
                Therapy = recordDTO.Therapy,
                Addition = recordDTO.Addition
            };

            return recordView;        
        }
    }
}
