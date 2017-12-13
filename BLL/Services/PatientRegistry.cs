using AutoMapper;
using BLL.DTO;
using BLL.Infrastructure;
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
    public class PatientRegistry : IPatientRegistry
    {
        IUnitOfWork Database { get; set; }

        public PatientRegistry(IUnitOfWork uow)
        {
            Database = uow;
            Mapper.Initialize(cfg => cfg.CreateMap<Patient, PatientDTO>());
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

            Database.Patients.Delete(patient.Id);
            Database.Save();
        }

        public IEnumerable<PatientDTO> Find(string name, string surname)
        {
            if (String.IsNullOrEmpty(name.Trim()) && String.IsNullOrEmpty(surname.Trim()))
                throw new ValidationException("Invalid data", "");

            return Mapper.Map<IEnumerable<Patient>, List<PatientDTO>>(Database.Patients.Find(x => x.Name == name && x.Surname == surname));
        }

        public void AddRecord(RecordDTO recordDTO)
        {
            if (recordDTO == null)
                throw new ArgumentNullException();

            Record record = new Record
            {
                DoctorId = recordDTO.DoctorId,
                PatientId = recordDTO.PatientId,
                Date = DateTime.Now,
                Diagnosis = recordDTO.Diagnosis,
                Therapy = recordDTO.Therapy,
                Addition = recordDTO.Addition
            };

            Database.Records.Create(record);
            Database.Save();
        }

        public IEnumerable<RecordDTO> GetRecords(PatientDTO patient)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Record, RecordDTO>());
            return Mapper.Map<IEnumerable<Record>, List<RecordDTO>>(Database.Records.GetAll().Where(x => x.Id == patient.Id));
        }
    }
}
