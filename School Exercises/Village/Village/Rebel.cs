using System;

namespace Village
{
    public class Rebel : Person
    {
        private int _harm;
        private int _age;

        public int Harm
        {
            get { return _harm; }
            private set {
                if (value <= 0)
                {
                    throw new ArgumentException("Harm should be greater than 0!");
                }
                _harm = value; 
            }
        }
        public override int Age
        {
            get { return _age; }
            set {
                if (value >= 50)
                {
                    throw new ArgumentException("Age should be less or equal to 50!");
                }
                _age = value;
            }
        }

        public Rebel(string name, int age, int harm) : base(name, age)
        {
            Age = age;
            Harm = harm;
        }
    }
}
