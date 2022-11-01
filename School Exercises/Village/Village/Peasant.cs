using System;

namespace Village
{
    public class Peasant : Person
    {
        private int _productivity;
        private int _age;

        public int Productivity
        {
            get { return _productivity; }
            private set {
                if (value <= 0)
                {
                    throw new ArgumentException("Productivity cannot be less or equal to 0!");
                }
                _productivity = value; 
            }
        }

        public override int Age
        {
            get { return _age; }
            set {
                if (value > 110)
                {
                    throw new ArgumentException("Age cannot be greater than 110!");
                }
                _age = value; 
            }
        }


        public Peasant(string name, int age, int productivity) : base(name, age)
        {
            Age = age;
            Productivity = productivity;
        }

        public override string ToString()
        {
            return $"Name: {Name}\nAge: {Age}\nProductivity: {Productivity}";
        }
    }
}
