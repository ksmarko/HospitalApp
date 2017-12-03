using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAP.Entities
{
    public class Contracts
    {
        public int Id { get; set; }
        public string Partner { get; set; }
        public string Target { get; set; }
        public int Sum { get; set; }
        public int Count { get; set; }
        public string Date { get; set; }
        public string Additionally { get; set; }

        public Contracts(int id, string partner, string target, int sum, int count, string date, string add)
        {
            Id = id;
            Partner = partner;
            Target = target;
            Sum = sum;
            Count = count;
            Date = date;
            Additionally = add;
        }
    }
}
