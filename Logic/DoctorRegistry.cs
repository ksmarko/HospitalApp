using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;
using Data;
using Logic.Entities;

namespace Logic
{
    public static class DoctorRegistry
    {
        static int index = 1;

        public static void ResetDB()
        {
            using (Data.DContext db = new DContext())
            {
                db.Database.Delete();
                db.SaveChanges();
                index -= index;
            }
        }

        public static void AddDoctor(string name, string surmane, string specialization)
        {
            using (Data.DContext db = new DContext())
            {
                Doctor doctor = new Doctor(name, surmane, specialization);
                doctor.Id = index;
                db.Doctors.Add(doctor);
                db.SaveChanges();
                index++;
            }
        }

        public static void RemoveDoctor(int Id)
        {
            using (Data.DContext db = new DContext())
            {
                foreach (var el in db.Doctors)
                    if (el.Id == Id)
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
                    if (doc.Name == name || doc.Surname == surname || doc.Specialization == specialization)
                        docList.Add(new DoctorL(doc.Id, doc.Name, doc.Surname, doc.Specialization));
            }

            return docList;
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
