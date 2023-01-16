using WildFarm.Abstractions.Foods;

namespace WildFarm.Abstractions.Animals
{
    public abstract class Animal
    {
        protected Animal(string name, double weight, int foodEaten)
        {
            Name = name;
            Weight = weight;
            FoodEaten = foodEaten;
            AskForFood();
        }

        public string Name { get; set; }
        public double Weight { get; set; }
        public int FoodEaten { get; set; }

        public abstract void AskForFood();
        public abstract void Feed(Food food);
    }
}
