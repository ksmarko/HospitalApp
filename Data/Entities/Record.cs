using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Record
    {
        public int Id { get; private set; }
        public int patId { get; set; }
        public int docId { get; set; }
        public string diagnosis { get; set; }
        public string therapy { get; set; }
        public string addition { get; set; }
        public string date { get; set; }

        public Record() { }

        public Record(int pat, int doc, string diagn, string therapy, string add)
        {
            this.patId = pat;
            this.docId = doc;
            this.diagnosis = diagn;
            this.therapy = therapy;
            this.addition = add;
            this.date = DateTime.Now.ToShortDateString();
        }
    }
}
