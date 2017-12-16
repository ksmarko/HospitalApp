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
    public class DoctorRegistry : IDoctorRegistry
    {
        EFUnitOfWork Database { get; set; }
        
        public DoctorRegistry()
        {
            Database = new EFUnitOfWork("DbConnection");
        }

        public IEnumerable<DoctorDTO> GetAll()
        {
            return Mapper.Map<IEnumerable<Doctor>, List<DoctorDTO>>(Database.Doctors.GetAll());
        }
        
        public void Add(DoctorDTO entity)
        {
            if (entity == null)
                throw new ArgumentNullException();

            Doctor doctor = new Doctor
            {
                Name = entity.Name,
                Surname = entity.Surname,
                Specialization = entity.Specialization
            };

            Database.Doctors.Create(doctor);
            Database.Save();
        }

        public void Remove(DoctorDTO entity)
        {
            Doctor doctor = Database.Doctors.Find(x => x.Id == entity.Id).FirstOrDefault();

            if (doctor == null)
                throw new ArgumentNullException();

            foreach (var el in Database.Schedules.GetAll().Where(x => x.DoctorId == doctor.Id))
                Database.Schedules.Delete(el.Id);

            Database.Doctors.Delete(doctor.Id);
            Database.Save();
        }

        public void Edit(DoctorDTO entity)
        {
            Doctor doctor = Database.Doctors.Find(x => x.Id == entity.Id).FirstOrDefault();
            
            if (doctor == null)
                throw new ArgumentNullException();

            doctor.Name = entity.Name;
            doctor.Surname = entity.Surname;
            doctor.Specialization = entity.Specialization;
            
            Database.Doctors.Update(doctor);
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public IEnumerable<DoctorDTO> FindAllData(string name, string surname)
        {
            if (String.IsNullOrEmpty(name.Trim()) && String.IsNullOrEmpty(surname.Trim()))
                throw new ArgumentNullException();

            return Mapper.Map<IEnumerable<Doctor>, List<DoctorDTO>>(Database.Doctors.Find(x => x.Name == name && x.Surname == surname));
        }

        public IEnumerable<DoctorDTO> Find(string name, string surname)
        {
            if (String.IsNullOrEmpty(name.Trim()) && String.IsNullOrEmpty(surname.Trim()))
                throw new ArgumentNullException();
            
            return Mapper.Map<IEnumerable<Doctor>, List<DoctorDTO>>(Database.Doctors.Find(x => x.Name == name && x.Surname == surname));
        }

        public DoctorDTO Find(int id)
        {
            return Mapper.Map<Doctor, DoctorDTO>(Database.Doctors.Get(id));
        }

        public IEnumerable<DoctorDTO> FindSpecialization(string specialization)
        {
            if (String.IsNullOrEmpty(specialization.Trim()))
                throw new ArgumentNullException();
            
            return Mapper.Map<IEnumerable<Doctor>, List<DoctorDTO>>(Database.Doctors.Find(x => x.Specialization == specialization));
        }
    }
}
