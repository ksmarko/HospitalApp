using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Record
    {
        public int Id { get; set; }
        public string Doctor { get; set; }
        public int PatientId { get; set; }
        public string Date { get; set; }
        public string Diagnosis { get; set; }
        public string Therapy { get; set; }
        public string Addition { get; set; }
    }
}
