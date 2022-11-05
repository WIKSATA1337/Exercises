using System;
using WildFarm.Abstractions.Foods;

namespace WildFarm.Abstractions.Animals.Mammals
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, int foodEaten, string livingRegion) : base(name, weight, foodEaten, livingRegion)
        {
        }

        public override void AskForFood()
        {
            Console.WriteLine("Squeak");
        }

        public override void Feed(Food food)
        {
            if (food is Vegetable || food is Fruit)
            {
                Weight += 0.10 * food.Quantity;
                FoodEaten += food.Quantity;
                return;
            }

            Console.WriteLine($"{GetType().Name} does not eat {food.GetType().Name}!");
        }
    }
}
