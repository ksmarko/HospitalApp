using Data;
using Data.Entities;
using Logic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public abstract class ScheduleManager
    {
        static int index = 1;

        public static void AddSchedule(DoctorL doc, PatientL pat, DateTime date, string time)
        {
            using (Data.DContext db = new DContext())
            {
                Schedule s = new Schedule(index, doc.Id, pat.Id, date, time);
                db.Schedules.Add(s);
                db.SaveChanges();
                index++;
            }
        }

        public static List<ScheduleL> GetSchedule(DoctorL doctor)
        {
            List<ScheduleL> card = new List<ScheduleL>();

            using (Data.DContext db = new DContext())
            {
                foreach (Schedule r in db.Schedules)
                    if (r.docId == doctor.Id)
                    {
                        card.Add(new ScheduleL(r.Id, PatientRegistry.FindPatient(r.docId).ToString(), r.date, r.time));
                    }
            }

            return card;
        }

        public static List<ScheduleL> GetSchedule(DoctorL doctor, DateTime date)
        {
            List<ScheduleL> card = new List<ScheduleL>();

            using (Data.DContext db = new DContext())
            {
                foreach (Schedule r in db.Schedules)
                    if (r.docId == doctor.Id && r.date == date)
                    {
                        card.Add(new ScheduleL(r.Id, PatientRegistry.FindPatient(r.docId).ToString(), r.date, r.time));
                    }
            }

            return card;
        }

        public static void EditSchedule(int id, DoctorL doc, PatientL pat, DateTime date, string time)
        {
            using (DContext db = new DContext())
            {
                var s = db.Schedules.Find(id);
                //foreach (Schedule s in db.Schedules)
                    //if (s.Id == id)
                    //{
                        s.docId = doc.Id;
                        s.patId = pat.Id;
                        s.date = date;
                        s.time = time;
                //}

                db.SaveChanges();
            }
        }
    }
}
