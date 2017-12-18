using System;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;

using Data.Entities;
using Data.Interfaces;

namespace Data.Repositories
{
    public class ScheduleRepository : IRepository<Schedule>
    {
        private DContext db;

        public ScheduleRepository(DContext context)
        {
            this.db = context;
        }

        public void Create(Schedule schedule)
        {
            db.Schedules.Add(schedule);
        }

        public void Delete(int id)
        {
            Schedule schedule = db.Schedules.Find(id);

            if (schedule != null)
                db.Schedules.Remove(schedule);
        }

        public IEnumerable<Schedule> Find(Func<Schedule, bool> predicate)
        {
            return db.Schedules.Where(predicate).ToList();
        }

        public Schedule Get(int id)
        {
            return db.Schedules.Find(id);
        }

        public IEnumerable<Schedule> GetAll()
        {
            return db.Schedules;
        }

        public void Update(Schedule schedule)
        {
            db.Entry(schedule).State = EntityState.Modified;
        }
    }
}
