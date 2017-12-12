using Data;
using Data.Entities;
using Logic.Entities;
using System.Collections.Generic;

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
                        db.Doctors.Remove(el);

                db.SaveChanges();
            }
        }
        
        public static List<DoctorL> GetDoctorList()
        {
            List<DoctorL> docList = new List<DoctorL>();

            using (Data.DContext db = new DContext())
            {
                foreach (Doctor doc in db.Doctors)
                    docList.Add(new DoctorL(doc.Id, doc.Name, doc.Surname, doc.Specialization));
            }

            return docList;
        }

        public static List<DoctorL> FindDoctor(string name, string surname, string specialization)
        {
            List<DoctorL> docList = new List<DoctorL>();

            using (Data.DContext db = new DContext())
            {
                foreach (Doctor doc in db.Doctors)
                    if (doc.Name.Contains(name) || doc.Surname.Contains(surname) || doc.Specialization.Contains(specialization))
                        docList.Add(new DoctorL(doc.Id, doc.Name, doc.Surname, doc.Specialization));
            }

            return docList;
        }

        public static DoctorL FindDoctor(int Id)
        {
            using (Data.DContext db = new DContext())
            {
                foreach (Doctor doc in db.Doctors)
                    if (doc.Id == Id)
                        return new DoctorL(doc.Id, doc.Name, doc.Surname, doc.Specialization);
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
