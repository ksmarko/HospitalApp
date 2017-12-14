using System.Data.Entity;
using Data.Entities;

namespace Data
{
    public class DContext : DbContext
    {
        public DContext(string connectionString) : base(connectionString)
        {
            Database.SetInitializer<DContext>(new DropCreateDatabaseIfModelChanges<DContext>());
            //Database.SetInitializer<DContext>(new DropCreateDatabaseAlways<DContext>());
        }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Record> Records { get; set; }
        public DbSet<Schedule> Schedules { get; set; }

    }
}
