using System;

namespace Village
{
    public abstract class Person
    {
        private string _name;
        private int _age;

        public virtual string Name
        {
            get { return _name; }
            private set
            {
                if (value.Length < 3 || value.Length > 30)
                {
                    throw new ArgumentException("Name should be between 3 and 30 characters!");
                }

                if (value.Contains(":"))
                {
                    throw new ArgumentException("Name must not contain \";\" ");
                }
                _name = value; 
            }
        }

        public virtual int Age
        {
            get { return _age; }
            set {
                if (value < 0)
                {
                    throw new ArgumentException("Age should be 0 or positive!");
                }
                _age = value; 
            }
        }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public override string ToString()
        {
            return $"Name: {Name}\nAge: {Age}";
        }
    }
}
