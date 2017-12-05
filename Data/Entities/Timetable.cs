using System.Collections.Generic;

namespace Data.Entities
{
    public sealed class Timetable
    {
        public int Id { get; set; }
        public List<string> dateTime;
        public List<Human> subject;

        public Timetable() { }

        public int Add(string datetime, Human human)
        {
            this.dateTime.Add(datetime);
            this.subject.Add(human);

            return dateTime.Count - 1;
        }

        public void Remove(int id)
        {
            this.dateTime.RemoveAt(id);
            this.subject.RemoveAt(id);
        }

        //автоматическое удаление, если дата-время уже прошла
    }
}
