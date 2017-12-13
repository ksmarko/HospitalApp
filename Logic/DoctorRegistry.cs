using Data;
using Data.Entities;
using Logic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logic
{
    public static class DoctorRegistry
    {
        static int index = 1;

        public static void AddDoctor(string name, string surname, string specialization)
        {
            using (DContext db = new DContext())
            {
                Doctor doctor = new Doctor(name, surname, specialization);
                doctor.Id = index;
                db.Doctors.Add(doctor);
                db.SaveChanges();
                index++;
            }
        }

        public static void RemoveDoctor(int id)
        {
            using (Data.DContext db = new DContext())
            {
                foreach (var el in db.Doctors)
                    if (el.Id == id)
                        el.available = false;

                db.SaveChanges();
            }
        }
        
        public static List<DoctorDTO> GetDoctorList()
        {
            List<DoctorDTO> docList = new List<DoctorDTO>();

            using (Data.DContext db = new DContext())
            {
                foreach (Doctor doc in db.Doctors)
                    if (doc.available == true)
                        docList.Add(new DoctorDTO(doc.Id, doc.Name, doc.Surname, doc.Specialization));
            }

            return docList;
        }

        public static List<DoctorDTO> FindDoctor(string name, string surname, string specialization)
        {
            if (!string.IsNullOrEmpty(specialization.Trim()))
                return GetDoctorList().FindAll(x => x.Name == name && x.Surname == surname && x.Specialization == specialization);
            else
                return GetDoctorList().FindAll(x => x.Name == name && x.Surname == surname);
        }

        public static DoctorDTO FindDoctor(int Id)
        {
            using (Data.DContext db = new DContext())
            {
                foreach (Doctor doc in db.Doctors)
                    if (doc.Id == Id)
                        return new DoctorDTO(doc.Id, doc.Name, doc.Surname, doc.Specialization);
            }

            return null;
        }

        public static void EditDoctorData(int id, string name, string surname, string specialization)
        {
            using (Data.DContext db = new DContext())
            {
                foreach (Doctor doc in db.Doctors)
                    if (doc.Id == id)
                    {
                        doc.Name = name;
                        doc.Surname = surname;
                        doc.Specialization = specialization;
                    }

                db.SaveChanges();
            }
        }
    }
}
