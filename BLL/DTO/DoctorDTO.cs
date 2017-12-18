using System;

namespace BLL.DTO
{
    public class DoctorDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Specialization { get; set; }

        public bool IsEnabled { get; set; }

        public override string ToString()
        {
            return String.Join(" ", Name, Surname, "(" + Specialization + ")");
        }
    }
}
