using System.Collections.Generic;

namespace Data.Entities
{
    public class Patient : Human
    {
        public List<Record> Card { get; set; }

        public Patient() : base()
        {
            Card = new List<Record>();
        }

        public Patient(string name, string surname) : base(name, surname)
        {
            Card = new List<Record>();
        }

        public override string ToString()
        {
            return string.Join(" ", Name, Surname);
        }
    }
}
