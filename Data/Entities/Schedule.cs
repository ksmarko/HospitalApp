using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Schedule
    {
        public int Id { get; set; }
        public int Doctor { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; }
    }
}
