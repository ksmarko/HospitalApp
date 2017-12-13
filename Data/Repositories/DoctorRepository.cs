using Data.Entities;
using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class DoctorRepository : IRepository<Doctor>
    {
        private DContext db;

        public DoctorRepository(DContext context)
        {
            this.db = context;
        }

        public IEnumerable<Doctor> GetAll()
        {
            return db.Doctors;
        }

        public Doctor Get(int id)
        {
            return db.Doctors.Find(id);
        }

        public void Create(Doctor doctor)
        {
            db.Doctors.Add(doctor);
        }

        public void Update(Doctor doctor)
        {
            db.Entry(doctor).State = EntityState.Modified;
        }

        public IEnumerable<Doctor> Find(Func<Doctor, Boolean> predicate)
        {
            return db.Doctors.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Doctor doctor = db.Doctors.Find(id);
            if (doctor != null)
                db.Doctors.Remove(doctor);
        }
    }
}
