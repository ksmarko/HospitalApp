using System.Collections.Generic;

namespace Data.Entities
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        //public ICollection<Record> Card { get; set; }
    }
}
