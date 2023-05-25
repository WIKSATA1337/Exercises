namespace Restaurant.Food.Food
{
    public class Cake : Dessert
    {
        private const double cakeGrams = 250;
        private const double cakeCalories = 1000;
        private const decimal cakePrice = 5;
        public Cake(string name)
            : base(name, 0, 0, 0)
        {
            Name = name;
        }

        public override double Grams { get => cakeGrams; }

        public override double Calories { get => cakeCalories; }

        public override decimal Price { get => cakePrice; }
    }
}
