using System;
using WildFarm.Abstractions.Foods;

namespace WildFarm.Abstractions.Animals.Mammals.Felines
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, int foodEaten, string livingRegion, string breed) : base(name, weight, foodEaten, livingRegion, breed)
        {
        }

        public override void AskForFood()
        {
            Console.WriteLine("Meow");
        }

        public override void Feed(Food food)
        {
            if (food is Vegetable || food is Meat)
            {
                FoodEaten += food.Quantity;
                Weight += 0.30 * food.Quantity;
                return;
            }

            Console.WriteLine($"{GetType().Name} does not eat {food.GetType().Name}!");
        }
    }
}
