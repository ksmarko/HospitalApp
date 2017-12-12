using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Entities
{
    public class ScheduleL
    {
        public int Id { get; set; }
        public string pat { get; set; }
        public DateTime date { get; set; }
        public string time { get; set; }

        public ScheduleL(int id, string pat, DateTime date, string time)
        {
            this.Id = id;
            this.pat = pat;
            this.date = date;
            this.time = time;
        }
    }
}
