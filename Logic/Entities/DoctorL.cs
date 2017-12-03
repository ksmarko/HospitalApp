using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Entities
{
    public class DoctorL
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Specialization { get; set; }

        public DoctorL(string name, string surname, string specialization)
        {
            this.Name = name;
            this.Surname = surname;
            this.Specialization = specialization;
        }
    }
}
