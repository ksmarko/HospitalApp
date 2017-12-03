using System.Data.Entity;
using Data.Entities;

namespace Data
{
    public class DContext : DbContext
    {
        public DContext() : base("DbConnection") { }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Card> PatientCard { get; set; }
        public DbSet<Timetable> Timetable { get; set; }
    }
}
