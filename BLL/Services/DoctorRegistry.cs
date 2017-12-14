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

            Database.Doctors.Delete(doctor.Id);
            Database.Save();
        }

        public void Edit(DoctorDTO entity)
        {
            //Console.WriteLine("Edit start. Input data: " + entity.Name + " " + entity.Surname + " " + entity.Specialization);
            Doctor doctor = Database.Doctors.Find(x => x.Id == entity.Id).FirstOrDefault();
            //Console.WriteLine("Doctor find. Data: " + doctor.Name + " " + doctor.Surname + " " + doctor.Specialization);
            
            if (doctor == null)
                throw new ArgumentNullException();

            doctor.Name = entity.Name;
            doctor.Surname = entity.Surname;
            doctor.Specialization = entity.Specialization;

            //Console.WriteLine("Info edit. Data: " + doctor.Name + " " + doctor.Surname + " " + doctor.Specialization);

            Database.Doctors.Update(doctor);

            //Console.WriteLine("Database updated: " + Database.Doctors.Find(x => x.Id == doctor.Id).FirstOrDefault().Name + Database.Doctors.Find(x => x.Id == doctor.Id).FirstOrDefault().Surname);
            Database.Save();
            //Console.WriteLine("Database saved: " + Database.Doctors.Find(x => x.Id == doctor.Id).FirstOrDefault().Name + Database.Doctors.Find(x => x.Id == doctor.Id).FirstOrDefault().Surname);

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

        public IEnumerable<DoctorDTO> FindSpecialization(string specialization)
        {
            if (String.IsNullOrEmpty(specialization.Trim()))
                throw new ArgumentNullException();
            
            return Mapper.Map<IEnumerable<Doctor>, List<DoctorDTO>>(Database.Doctors.Find(x => x.Specialization == specialization));
        }
    }
}
