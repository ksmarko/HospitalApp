using Data;
using Data.Entities;
using System;
using System.Collections;
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

        private List<RecordL> Card { get; set; }
        
        public PatientL(int id, string name, string surname)
        {
            this.Id = id;
            this.Name = name;
            this.Surname = surname;
            Card = new List<RecordL>();
        }

        public override string ToString()
        {
            return string.Join(" ", Name, Surname);
        }
    }
}
