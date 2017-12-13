using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using Data.Entities;
using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class TimeManager : IManager
    {
        IUnitOfWork Database { get; set; }

        public TimeManager(IUnitOfWork uow)
        {
            Database = uow;
            Mapper.Initialize(cfg => cfg.CreateMap<Schedule, ScheduleDTO>());
        }

        public void Add(ScheduleDTO entity)
        {
            if (entity == null)
                throw new ArgumentNullException();
            
            Schedule schedule = new Schedule
            {
                Doctor = Database.Doctors.Find(x => x.Id == entity.DoctorId).FirstOrDefault(),
                Patient = Database.Patients.Find(x => x.Id == entity.PatientId).FirstOrDefault(),
                Date = entity.Date,
                Time = entity.Time
            };

            Database.Schedules.Create(schedule);
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public void Edit(ScheduleDTO entity)
        {
            Schedule schedule = Database.Schedules.Find(x => x.Id == entity.Id).FirstOrDefault();

            if (schedule == null)
                throw new ArgumentNullException();

            schedule.Doctor = Database.Doctors.Find(x => x.Id == entity.DoctorId).FirstOrDefault();
            schedule.Patient = Database.Patients.Find(x => x.Id == entity.PatientId).FirstOrDefault();
            schedule.Date = entity.Date;
            schedule.Time = entity.Time;

            Database.Schedules.Update(schedule);
            Database.Save();
        }

        public IEnumerable<ScheduleDTO> GetAll()
        {
            return Mapper.Map<IEnumerable<Schedule>, List<ScheduleDTO>>(Database.Schedules.GetAll());
        }

        public IEnumerable<ScheduleDTO> GetByDate(DateTime date)
        {
            return Mapper.Map<IEnumerable<Schedule>, List<ScheduleDTO>>(Database.Schedules.GetAll().Where(x => x.Date == date));
        }

        public IEnumerable<ScheduleDTO> GetByDoctor(DoctorDTO doctorDTO)
        {
            Doctor doctor = Database.Doctors.Find(x => x.Id == doctorDTO.Id).FirstOrDefault();

            if (doctor == null)
                throw new ArgumentNullException();

            return Mapper.Map<IEnumerable<Schedule>, List<ScheduleDTO>>(Database.Schedules.GetAll().Where(x => x.Doctor == doctor));
        }

        public void Remove(ScheduleDTO entity)
        {
            Schedule schedule = Database.Schedules.Find(x => x.Id == entity.Id).FirstOrDefault();

            if (schedule == null)
                throw new ArgumentNullException();

            Database.Schedules.Delete(schedule.Id);
            Database.Save();
        }
    }
}
