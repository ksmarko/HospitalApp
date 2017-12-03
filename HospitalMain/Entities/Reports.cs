using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAP.Entities
{
    public class Reports
    {
        public int Id { get; set; }
        public string Target { get; set; }
        public string Date { get; set; }
        public string Additionally { get; set; }

        public Reports(int id, string target, string date, string add)
        {
            Id = id;
            Target = target;
            Date = date;
            Additionally = add;
        }
    }
}
