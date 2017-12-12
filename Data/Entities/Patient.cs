using System.Collections.Generic;

namespace Data.Entities
{
    public class Patient : Human
    {
        public List<Record> Card { get; set; }

        public Patient() : base()
        {
        }

        public Patient(string name, string surname) : base(name, surname)
        {
            Card = new List<Record>();
        }
    }
}
