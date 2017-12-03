namespace Data.Entities
{
    public class Doctor : Human
    {
        //public int Id { get; set; }
        public string Specialization { get; set; }
        public string dateTime { get; set; } = "Пн-пт 9:00 - 18:00";
        public Timetable timeTable;

        public Doctor() { }

        public Doctor(string name, string surname, string specialization)
        {
            this.Name = name;
            this.Surname = surname;
            this.Specialization = specialization;
        }

        public Doctor(string name, string surname, string specialization, string datetime, Timetable timetable)
        {
            this.Name = name;
            this.Surname = surname;
            this.Specialization = specialization;
            this.dateTime = datetime;
            this.timeTable = timetable;
        }

        public void AddToTimetable(string datetime, Patient patient)
        {
            this.timeTable.Add(datetime, patient);
        }

        public void RemoveFromTimetable(int id)
        {
            this.timeTable.Remove(id);
        }
        
        public void SetDateTime(string datetime)
        {
            this.dateTime = datetime;
        }

        public void EditDoctorInfo(string name, string surname, string specialization, string datetime)
        {
            if (name != null)
                this.Name = name;

            if (surname != null)
                this.Surname = surname;

            if (specialization != null)
                this.Specialization = specialization;

            if (dateTime != null)
                this.dateTime = datetime;
        }

        public override string ToString()
        {
            return string.Join(" ", Name, Surname);
        }
    }
}
