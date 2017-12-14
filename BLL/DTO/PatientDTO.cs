using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class PatientDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public override string ToString()
        {
            return string.Join(" ", Name, Surname);
        }
    }
}
