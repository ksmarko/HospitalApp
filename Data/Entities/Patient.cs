namespace Data.Entities
{
    public class Patient : Human
    {
        //public int Id { get; set; }
        public Card card;
        public Timetable timetable;

        public Patient() { }

        public Patient(string name, string surname)
        {
            this.Name = name;
            this.Surname = surname;
        }

        public int AddToCard(string datetime, Doctor doctor, string diagnosis, string therapy)
        {
            card.DateTime.Add(datetime);
            card.Doctor.Add(doctor);
            card.Diagnosis.Add(diagnosis);
            card.Therapy.Add(therapy);

            return card.DateTime.Count - 1;
        }

        public string FindInCard(int id)
        {
            return string.Join(", ", new string[4] 
            {
                card.DateTime[id].ToString(),
                card.Doctor[id].ToString(),
                card.Diagnosis[id].ToString(),
                card.Therapy[id].ToString()
            });
        }

        public string LastCardRecord()
        {
            return FindInCard(card.recordsCount - 1);
        }
    }
}
