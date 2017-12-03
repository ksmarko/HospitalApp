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
        public static void ResetDB()
        {
            using (Data.DContext db = new DContext())
            {
                db.Database.Delete();
                db.SaveChanges();
            }
        }

        public static void AddDoctor(string name, string surmane, string specialization)
        {
            using (Data.DContext db = new DContext())
            {
                Doctor doctor = new Doctor(name, surmane, specialization);
                
                db.Doctors.Add(doctor);
                db.SaveChanges();
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

        //public static List<string> GetDoctorList()
        //{
        //    List<string> docList = new List<string>();

        //    using (Data.DContext db = new DContext())
        //    {
        //        foreach (Doctor doc in db.Doctors)
        //            docList.Add(string.Join(", ", new string[3] {doc.Name, doc.Surname, doc.Specialization }));
        //    }

        //    return docList;
        //}

        public static List<DoctorL> GetDoctorList()
        {
            List<DoctorL> docList = new List<DoctorL>();

            using (Data.DContext db = new DContext())
            {
                foreach (Doctor doc in db.Doctors)
                    docList.Add(new DoctorL(doc.Name, doc.Surname, doc.Specialization));
            }

            return docList;
        }

        public static List<Doctor> FindDoctor(string name, string surname, string specialization, string datetime)
        {
            return null;
        }

        public static void EditDoctorData(int Id, string [] data)
        {
            foreach (var el in data)
            {

            }
        }
    }
}
