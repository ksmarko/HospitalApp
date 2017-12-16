﻿using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    interface IManager : IRegistry<ScheduleDTO>
    {
        IEnumerable<ScheduleDTO> GetByDoctor(DoctorDTO doctorDTO);
        void Remove(int id);
    }
}
