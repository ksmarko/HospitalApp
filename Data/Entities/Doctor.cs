namespace Data.Entities
{
    public class Doctor : Human
    {
        public string Specialization { get; set; }

        public Doctor() : base() { }

        public Doctor(string name, string surname, string specialization) : base(name, surname)
        {
            this.Specialization = specialization;
        }

        public override string ToString()
        {
            return string.Join(" ", Name, Surname);
        }
    }
}
