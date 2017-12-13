using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Entities
{
    public class DoctorDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Specialization { get; set; }

        public DoctorDTO(int id, string name, string surname, string specialization)
        {
            this.Id = id;
            this.Name = name;
            this.Surname = surname;
            this.Specialization = specialization;
        }

        public override string ToString()
        {
            return string.Join(" ", Name, Surname);
        }
    }
}
