namespace Data.Entities
{
    public class Doctor : Human
    {
        public bool available { get; set; }
        public string Specialization { get; set; }

        public Doctor() : base() { }

        public Doctor(string name, string surname, string specialization) : base(name, surname)
        {
            this.available = true;
            this.Specialization = specialization;
        }
    }
}
