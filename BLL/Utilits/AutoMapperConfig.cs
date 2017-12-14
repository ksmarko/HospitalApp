using AutoMapper;
using BLL.DTO;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Utilits
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
                {
                    cfg.CreateMap<Doctor, DoctorDTO>();
                    cfg.CreateMap<Patient, PatientDTO>();
                    cfg.CreateMap<Record, RecordDTO>();
                    cfg.CreateMap<Schedule, ScheduleDTO>();
                });
        }
    }
}
