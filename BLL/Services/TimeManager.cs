﻿using System;
using System.Linq;
using System.Collections.Generic;

using AutoMapper;

using BLL.DTO;
using BLL.Interfaces;
using BLL.Infrastructure;

using Data.Entities;
using Data.Repositories;

namespace BLL.Services
{
    public class TimeManager : IManager
    {
        EFUnitOfWork Database { get; set; }

        public TimeManager()
        {
            Database = new EFUnitOfWork();
        }

        public void Add(ScheduleDTO entity)
        {
            if (entity == null)
                throw new ArgumentNullException();

            Schedule schedule = new Schedule
            {
                DoctorId = Database.Doctors.Find(x => x.Id == entity.DoctorId).FirstOrDefault().Id,
                PatientId = entity.PatientId,
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

            if (schedule == null)
                throw new ArgumentNullException();
            
            if (schedule.PatientId == 0)
                throw new ValidationException("It's doctor's timetable", "");

            EditAnyway(entity);
        }

        public void EditAnyway(ScheduleDTO entity)
        {
            Schedule schedule = Database.Schedules.Find(x => x.Id == entity.Id).FirstOrDefault();

            if (schedule == null)
                throw new ArgumentNullException();

            schedule.DoctorId = Database.Doctors.Find(x => x.Id == entity.DoctorId).FirstOrDefault().Id;
            schedule.Date = entity.Date;
            schedule.Time = entity.Time;

            if (schedule.PatientId == 0)
            {
                var list = Database.Schedules.Find(x => x.DoctorId == schedule.DoctorId && TimeParsing(entity.Time).Contains(x.Time));

                foreach (var el in list)
                    Database.Schedules.Delete(el.Id);
            }

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

            return Mapper.Map<IEnumerable<Schedule>, List<ScheduleDTO>>(Database.Schedules.GetAll().Where(x => x.DoctorId == doctor.Id));
        }

        public void Remove(ScheduleDTO entity)
        {
            Remove(entity.Id);
        }

        public void Remove(int id)
        {
            Schedule schedule = Database.Schedules.Find(x => x.Id == id).FirstOrDefault();

            if (schedule == null)
                throw new ArgumentNullException();

            if (schedule.PatientId == 0)
                throw new ValidationException("Possible loss of patients", "");

            RemoveAnyway(id);
        }

        public void RemoveAnyway(int id)
        {
            Schedule schedule = Database.Schedules.Find(x => x.Id == id).FirstOrDefault();

            if (schedule == null)
                throw new ArgumentNullException();
            
            if (schedule.PatientId == 0)
            {
                var list = Database.Schedules.Find(x => x.DoctorId == schedule.DoctorId && TimeParsing(schedule.Time).Contains(x.Time) && x.Date == schedule.Date);

                foreach (var el in list)
                    Database.Schedules.Delete(el.Id);
            }

            Database.Schedules.Delete(schedule.Id);
            Database.Save();
        }

        public IEnumerable<string> TimeParsing(string time)
        {
            if (string.IsNullOrEmpty(time.Trim()))
                throw new ValidationException("Invalid time string", "");

            List<string> hours = new List<string>();
            
            char[] arr = new char[] { ' ', '-', ' ' };

            string[] tStart = time.Split(arr, StringSplitOptions.RemoveEmptyEntries);
            
            int start = Convert.ToInt32(tStart[0].Substring(0, tStart[0].Length - 3));
            int end = Convert.ToInt32(tStart[1].Substring(0, tStart[1].Length - 3));

            for (int i = start; i < end + 1; i++)
            {
                hours.Add(i + ":00");
                hours.Add(i + ":30");
            }

            return hours;
        }
    }
}
