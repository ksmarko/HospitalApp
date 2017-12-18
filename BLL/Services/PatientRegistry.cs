using System;
using System.Linq;
using System.Collections.Generic;

using AutoMapper;

using BLL.DTO;
using BLL.Interfaces;

using Data.Entities;
using Data.Repositories;

namespace BLL.Services
{
    public class PatientRegistry : IPatientRegistry
    {
        EFUnitOfWork Database { get; set; }

        public PatientRegistry()
        {
            Database = new EFUnitOfWork();
        }

        public void Add(PatientDTO entity)
        {
            if (entity == null)
                throw new ArgumentNullException();

            Patient patient = new Patient
            {
                Name = entity.Name,
                Surname = entity.Surname
            };

            Database.Patients.Create(patient);
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public void Edit(PatientDTO entity)
        {
            Patient patient = Database.Patients.Find(x => x.Id == entity.Id).FirstOrDefault();

            if (patient == null)
                throw new ArgumentNullException();

            patient.Name = entity.Name;
            patient.Surname = entity.Surname;

            Database.Patients.Update(patient);
            Database.Save();
        }

        public IEnumerable<PatientDTO> GetAll()
        {
            return Mapper.Map<IEnumerable<Patient>, List<PatientDTO>>(Database.Patients.GetAll());
        }

        public void Remove(PatientDTO entity)
        {
            Patient patient = Database.Patients.Find(x => x.Id == entity.Id).FirstOrDefault();

            if (patient == null)
                throw new ArgumentNullException();
            
            foreach (var el in Database.Schedules.Find(x => x.PatientId == patient.Id))
                Database.Schedules.Delete(el.Id);

            Database.Patients.Delete(patient.Id);
            Database.Save();
        }

        public IEnumerable<PatientDTO> Find(string name, string surname)
        {
            if (String.IsNullOrEmpty(name.Trim()) && String.IsNullOrEmpty(surname.Trim()))
                throw new ArgumentNullException("Invalid data", "");

            return Mapper.Map<IEnumerable<Patient>, List<PatientDTO>>(Database.Patients.Find(x => x.Name == name && x.Surname == surname));
        }

        public PatientDTO Find(int id)
        {
            return Mapper.Map<Patient, PatientDTO>(Database.Patients.Get(id));
        }

        public void AddRecord(RecordDTO recordDTO)
        {
            if (recordDTO == null)
                throw new ArgumentNullException();

            Record record = new Record
            {
                DoctorId = recordDTO.DoctorId,
                PatientId = recordDTO.PatientId,
                Date = DateTime.Now.ToShortDateString(),
                Diagnosis = recordDTO.Diagnosis,
                Therapy = recordDTO.Therapy,
                Addition = recordDTO.Addition
            };

            Database.Records.Create(record);
            Database.Save();
        }

        public IEnumerable<RecordDTO> GetRecords(PatientDTO patient)
        {
            return Mapper.Map<IEnumerable<Record>, List<RecordDTO>>(Database.Records.GetAll().Where(x => x.PatientId == patient.Id));
        }
    }
}
