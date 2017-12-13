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

        public static List<PatientDTO> GetPatientList()
        {
            List<PatientDTO> patList = new List<PatientDTO>();

            using (Data.DContext db = new DContext())
            {
                foreach (Patient pat in db.Patients)
                    patList.Add(new PatientDTO(pat.Id, pat.Name, pat.Surname));
            }

            return patList;
        }

        public static void AddDataToCard(PatientDTO pat, DoctorDTO doc, string diagnosis, string therapy, string add)
        {
            using (Data.DContext db = new DContext())
            {
                Record r = new Record(pat.Id, doc.Id, diagnosis, therapy, add);
                db.Records.Add(r);
                db.SaveChanges();
            }
        }

        public static List<RecordDTO> GetAllRecords(PatientDTO pat)
        {
            List<RecordDTO> card = new List<RecordDTO>();

            using (Data.DContext db = new DContext())
            {
                foreach (Record r in db.Records)
                    if (r.patId == pat.Id)
                        card.Add(new RecordDTO(DoctorRegistry.FindDoctor(r.docId).Specialization, DoctorRegistry.FindDoctor(r.docId).ToString(), r.diagnosis, r.therapy, r.addition));
            }

            return card;
        }

        public static PatientDTO FindPatient(int id)
        {
            using (Data.DContext db = new DContext())
            {
                foreach (Patient pat in db.Patients)
                    if (pat.Id == id)
                        return new PatientDTO(pat.Id, pat.Name, pat.Surname);
            }

            return null;
        }

        public static List<PatientDTO> FindPatient(string name, string surname)
        {
            List<PatientDTO> patients = new List<PatientDTO>();

            using (Data.DContext db = new DContext())
            {
                foreach (Patient pat in db.Patients)
                    if (pat.Name == name && pat.Surname == surname)
                        patients.Add(new PatientDTO(pat.Id, pat.Name, pat.Surname));
            }

            return patients;
        }
    }
}
