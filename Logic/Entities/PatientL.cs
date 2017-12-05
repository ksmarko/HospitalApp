using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Entities
{
    public class PatientL
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public PatientL(int id, string name, string surname)
        {
            this.Id = id;
            this.Name = name;
            this.Surname = surname;
        }

        public override string ToString()
        {
            return string.Join(" ", Name, Surname);
        }
    }
}
