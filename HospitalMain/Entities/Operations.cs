using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAP.Entities
{
    public class Operations
    {
        public int Id { get; set; }
        public string Operation { get; set; }
        public int Sum { get; set; }
        public string Additionally { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        
        public Operations(string date, string operation, int sum, string add)
        {
            Date = date;
            Operation = operation;
            Sum = sum;
            Additionally = add;
        }
    }
}
