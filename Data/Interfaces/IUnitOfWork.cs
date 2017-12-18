using System;

using Data.Entities;

namespace Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Doctor> Doctors { get; }
        IRepository<Patient> Patients { get; }
        IRepository<Record> Records { get; }
        IRepository<Schedule> Schedules { get; }
        void Save();
    }
}
