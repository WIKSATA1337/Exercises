using System;

namespace PizzaCalories
{
    public class Topping
    {
		private const double BaseCaloriesPerGram = 2;
		private string type;
        private double grams;

        public Topping(string type, double grams)
        {
            Type = type;
            Grams = grams;
        }

		private const double Meat = 1.2;
        private const double Veggies = 0.8;
        private const double Cheese = 1.1;
        private const double Sauce = 0.9;

        public string Type
		{
            get { return type; }
            private set
            {
                bool ValidType = value.ToLower() == "meat" ? true
                    : value.ToLower() == "veggies" ? true
                    : value.ToLower() == "cheese" ? true
                    : value.ToLower() == "sauce" ? true
                    : false;

                if (!ValidType)
                {
                    throw new Exception($"Cannot place {value} on top of your pizza.");
                }
                type = value;
            }
		}
        public double Grams
        {
            get { return grams; }
            private set
            {
                if (value > 50 || value < 1)
                {
                    throw new Exception($"{Type} weight should be in the range [1..50].");
                }
                grams = value;
            }
        }


        public double GetCalories()
        {
            double typeCaloriesPG = Type.ToLower() == "meat" ? Meat
                    : Type.ToLower() == "veggies" ? Veggies
                    : Type.ToLower() == "cheese" ? Cheese
                    : Sauce;

            return typeCaloriesPG * Grams * BaseCaloriesPerGram;
        }
    }
}
