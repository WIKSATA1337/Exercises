using BirthdayCelebrations.Interfaces;

namespace BirthdayCelebrations.Classes
{
    public class Pet : IBirthable
    {
        public string Name { get; set; }
        public string Birthdate { get; set; }

        public Pet(string name, string birthdate)
        {
            Name = name;
            Birthdate = birthdate;
        }
    }
}
