using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Entities
{
    public class RecordDTO
    {
        public string Date { get; set; }
        public string Specialization { get; set; }
        public string Doctor { get; set; }
        public string Diagnosis { get; set; }
        public string Therapy { get; set; }
        public string Addition { get; set; }

        public RecordDTO(string specialization, string doc, string diagn, string therapy, string add)
        {
            this.Specialization = specialization;
            this.Doctor = doc;
            this.Diagnosis = diagn;
            this.Therapy = therapy;
            this.Addition = add;
            this.Date = DateTime.Now.ToShortDateString();
        }
    }
}
