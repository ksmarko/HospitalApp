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
    public abstract class PatientRegistry
    {
        static int index = 1;

        public static void AddPatient(string name, string surname)
        {
            using (DContext db = new DContext())
            {
                Patient patient = new Patient(name, surname);
                patient.Id = index;
                db.Patients.Add(patient);
                db.SaveChanges();
                index++;
            }
        }

        public static void RemovePatient(int id)
        {
            using (Data.DContext db = new DContext())
            {
                foreach (var el in db.Patients)
                    if (el.Id == id)
                        db.Patients.Remove(el);

                db.SaveChanges();
            }
        }

        public static List<PatientL> GetPatientList()
        {
            List<PatientL> patList = new List<PatientL>();

            using (Data.DContext db = new DContext())
            {
                foreach (Patient pat in db.Patients)
                    patList.Add(new PatientL(pat.Id, pat.Name, pat.Surname));
            }

            return patList;
        }

    }
}
