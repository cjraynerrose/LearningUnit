namespace PersonDomain
{
    public class Person
    {
        public int Id { get; private set; }
        public string Name { get; }
        public string Nationality { get; }

        public Person(string name, string nationality)
        {
            Name = name;
            Nationality = nationality;
        }

        public bool IsValid()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(Nationality))
            {
                return false;
            }

            return true;
        }

        public Person(int id, string name, string nationality)
        {
            Id = id;
            Name = name;
            Nationality = nationality;
        }

        public void SetId(int id)
        {
            Id = id;
        }
    }
}
