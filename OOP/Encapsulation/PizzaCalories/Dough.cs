using System;

namespace PizzaCalories
{
    public class Dough
    {
		private const int DoughCaloriesPerGram = 2;

        private string flourType;
        private string bakingTechnique;
        private double weight;

        private const double White = 1.5;
		private const double Wholegrain = 1.0;
        private const double Crispy = 0.9;
        private const double Chewy = 1.1;
        private const double Homemade = 1.0;

        public Dough(string flourType, string bakingTechnique, double weight)
		{
			FlourType = flourType;
			BakingTechnique = bakingTechnique;
			Weight = weight;
		}

		public string FlourType
		{
            get { return flourType; }
            private set
            {
                bool ValidTypeOfDough = value.ToLower() == "white" ? true
                    : value.ToLower() == "wholegrain" ? true
                    : false;

				if (!ValidTypeOfDough)
				{
					throw new ArgumentException("Invalid type of dough.");
				}
				flourType = value; 
			}
		}
		public string BakingTechnique
		{
            get { return bakingTechnique; }
            private set
            {
                bool ValidTypeOfDough = value.ToLower() == "crispy" ? true
                    : value.ToLower() == "chewy" ? true
                    : value.ToLower() == "homemade" ? true
                    : false;

                if (!ValidTypeOfDough)
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                bakingTechnique = value; 
			}
		}

        public double Weight
        {
            get { return weight; }
            private set
            {
                if (value > 200 || value < 1)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
                weight = value;
            }
        }

        public double GetCalories()
        {
            double flourModifier = FlourType.ToLower() == "white" ? White : Wholegrain;
            double bakingModifier = BakingTechnique.ToLower() == "crispy" ? Crispy 
                : BakingTechnique.ToLower() == "chewy" ? Chewy 
                : Homemade;

            return DoughCaloriesPerGram * weight * flourModifier * bakingModifier;
        }
    }
}
