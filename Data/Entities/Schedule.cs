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
        public int docId { get; set; }
        public int patId { get; set; }
        public DateTime date { get; set; }
        public string time { get; set; }

        public Schedule() { }

        public Schedule(int id, int doc, int pat, DateTime date, string time)
        {
            this.Id = id;
            this.docId = doc;
            this.patId = pat;
            this.date = date;
            this.time = time;
        }
    }
}
