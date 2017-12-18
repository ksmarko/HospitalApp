using AutoMapper;

using BLL.DTO;
using Data.Entities;

namespace BLL.Infrastructure
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
