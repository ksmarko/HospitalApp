using BLL.DTO;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    interface IDoctorRegistry : IRegistry<DoctorDTO>
    {
        IEnumerable<DoctorDTO> Find(string name, string surname);
        IEnumerable<DoctorDTO> FindSpecialization(string specialization);
    }
}
