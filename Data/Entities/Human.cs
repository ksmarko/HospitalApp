namespace Data.Entities
{
    public abstract class Human
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public Human()
        { }

        public Human(string name, string surname)
        {
            this.Name = name;
            this.Surname = surname;
        }

        public override string ToString()
        {
            return string.Join(" ", Name, Surname);
        }
    }
}
