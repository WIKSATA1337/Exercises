using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OldestFamilyMember
{
    public class Family
    {
        List<Person> people;

        public Family()
        {
            people = new List<Person>();
        }

        public void AddMember(Person member)
        {
            people.Add(member);
        }

        public Person GetOldestMember()
        {
            var oldestPerson = people.OrderByDescending(p => p.Age).FirstOrDefault();
            return oldestPerson;
        }
    }
}
