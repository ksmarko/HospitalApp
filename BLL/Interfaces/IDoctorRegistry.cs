using System.Collections.Generic;

using BLL.DTO;

namespace BLL.Interfaces
{
    interface IDoctorRegistry : IRegistry<DoctorDTO>
    {
        IEnumerable<DoctorDTO> Find(string name, string surname);
        IEnumerable<DoctorDTO> FindSpecialization(string specialization);
    }
}
