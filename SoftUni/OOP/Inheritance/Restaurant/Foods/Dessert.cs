using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Food
{
    public class Dessert : Food
    {
        private double calories;

        public Dessert(string name, decimal price, double grams, double calories) : base(name, price, grams)
        {
            Calories = calories;
        }

        public virtual double Calories
        {
            get { return calories; }
            set { calories = value; }
        }
    }
}
