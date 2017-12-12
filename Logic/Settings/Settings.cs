using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Settings
{
    class Settings
    {
        public static void ResetDB()
        {
            using (DContext db = new DContext())
            {
                db.Database.Delete();
                db.SaveChanges();
            }
        }
    }
}
