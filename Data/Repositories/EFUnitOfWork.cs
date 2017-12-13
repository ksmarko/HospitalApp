using Data.Entities;
using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private DContext db;
        private DoctorRepository doctorRepository;
        private PatientRepository patientRepository;
        private RecordRepository recordRepository;
        private ScheduleRepository scheduleRepository;

        public EFUnitOfWork(string connectionString)
        {
            db = new DContext(connectionString);
        }

        public IRepository<Doctor> Doctors
        {
            get
            {
                if (doctorRepository == null)
                    doctorRepository = new DoctorRepository(db);
                return doctorRepository;
            }
        }

        public IRepository<Patient> Patients
        {
            get
            {
                if (patientRepository == null)
                    patientRepository = new PatientRepository(db);
                return patientRepository;
            }
        }

        public IRepository<Record> Records
        {
            get
            {
                if (recordRepository == null)
                    recordRepository = new RecordRepository(db);
                return recordRepository;
            }
        }

        public IRepository<Schedule> Schedules
        {
            get
            {
                if (scheduleRepository == null)
                    scheduleRepository = new ScheduleRepository(db);
                return scheduleRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
