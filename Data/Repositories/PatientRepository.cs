using System;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;

using Data.Entities;
using Data.Interfaces;

namespace Data.Repositories
{
    public class PatientRepository : IRepository<Patient>
    {
        private DContext db;

        public PatientRepository(DContext context)
        {
            this.db = context;
        }

        public IEnumerable<Patient> GetAll()
        {
            return db.Patients;
        }

        public Patient Get(int id)
        {
            return db.Patients.Find(id);
        }

        public void Create(Patient patient)
        {
            db.Patients.Add(patient);
        }

        public void Update(Patient patient)
        {
            db.Entry(patient).State = EntityState.Modified;
        }

        public IEnumerable<Patient> Find(Func<Patient, Boolean> predicate)
        {
            return db.Patients.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Patient patient = db.Patients.Find(id);

            if (patient != null)
                db.Patients.Remove(patient);
        }
    }
}
