using System;

namespace ComparingObjects
{
    public class Person : IComparable<Person>
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Town { get; set; }

        public Person(string name, int age, string town)
        {
            Name = name;
            Age = age;
            Town = town;
        }

        public int CompareTo(Person otherPerson)
        {
            if (this.Name == otherPerson.Name && this.Age == otherPerson.Age && this.Town == otherPerson.Town)
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }
    }
}
