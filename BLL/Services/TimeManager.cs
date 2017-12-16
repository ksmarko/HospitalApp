using AutoMapper;
using BLL.DTO;
using BLL.Infrastructure;
using BLL.Interfaces;
using Data.Entities;
using Data.Interfaces;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class TimeManager : IManager
    {
        EFUnitOfWork Database { get; set; }

        public TimeManager()
        {
            Database = new EFUnitOfWork("DbConnection");
        }

        public void Add(ScheduleDTO entity)
        {
            if (entity == null)
                throw new ArgumentNullException();
            
            Schedule schedule = new Schedule
            {
                Doctor = Database.Doctors.Find(x => x.Id == entity.Doctor).FirstOrDefault().Id,
                Date = entity.Date,
                Time = entity.Time,
                Addition = entity.Addition
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
            
            foreach (var el in GetAll())
                Console.WriteLine(el.Id + "  " + el.Time);

            if (schedule == null)
                throw new ArgumentNullException();

            schedule.Doctor = Database.Doctors.Find(x => x.Id == entity.Doctor).FirstOrDefault().Id;
            schedule.Date = entity.Date;
            schedule.Time = entity.Time;

            Database.Schedules.Update(schedule);
            Database.Save();
        }

        public IEnumerable<ScheduleDTO> GetAll()
        {
            return Mapper.Map<IEnumerable<Schedule>, List<ScheduleDTO>>(Database.Schedules.GetAll());
        }

        public IEnumerable<ScheduleDTO> GetByDoctor(DoctorDTO doctorDTO)
        {
            Doctor doctor = Database.Doctors.Find(x => x.Id == doctorDTO.Id).FirstOrDefault();

            if (doctor == null)
                throw new ArgumentNullException();

            return Mapper.Map<IEnumerable<Schedule>, List<ScheduleDTO>>(Database.Schedules.GetAll().Where(x => x.Doctor == doctor.Id));
        }
        

        public void Remove(ScheduleDTO entity)
        {
            Schedule schedule = Database.Schedules.Find(x => x.Id == entity.Id).FirstOrDefault();

            if (schedule == null)
                throw new ArgumentNullException();
            
            Database.Schedules.Delete(schedule.Id);
            Database.Save();
        }

        public void Remove(int id)
        {
            Schedule schedule = Database.Schedules.Find(x => x.Id == id).FirstOrDefault();

            if (schedule == null)
                throw new ArgumentNullException();

            Database.Schedules.Delete(schedule.Id);
            Database.Save();
        }
    }
}
