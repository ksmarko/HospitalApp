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
    public class RecordRepository : IRepository<Record>
    {
        private DContext db;

        public RecordRepository(DContext context)
        {
            this.db = context;
        }

        public IEnumerable<Record> GetAll()
        {
            return db.Records;
        }

        public Record Get(int id)
        {
            return db.Records.Find(id);
        }

        public void Create(Record record)
        {
            db.Records.Add(record);
        }

        public void Update(Record record)
        {
            db.Entry(record).State = EntityState.Modified;
        }

        public IEnumerable<Record> Find(Func<Record, Boolean> predicate)
        {
            return db.Records.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Record record = db.Records.Find(id);
            if (record != null)
                db.Records.Remove(record);
        }
    }
}
