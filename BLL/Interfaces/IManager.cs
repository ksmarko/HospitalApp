using System.Collections.Generic;

using BLL.DTO;

namespace BLL.Interfaces
{
    interface IManager : IRegistry<ScheduleDTO>
    {
        IEnumerable<ScheduleDTO> GetByDoctor(DoctorDTO doctorDTO);
        void Remove(int id);
    }
}
