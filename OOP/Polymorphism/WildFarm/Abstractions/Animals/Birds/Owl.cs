using System;
using WildFarm.Abstractions.Foods;

namespace WildFarm.Abstractions.Animals.Birds
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, int foodEaten, double wingSize) : base(name, weight, foodEaten, wingSize)
        {
        }

        public override void AskForFood()
        {
            Console.WriteLine("Hoot Hoot");
        }

        public override void Feed(Food food)
        {
            if (food is Meat)
            {
                FoodEaten += food.Quantity;
                Weight += 0.25 * food.Quantity;
                return;
            }

            Console.WriteLine($"{GetType().Name} does not eat {food.GetType().Name}!");
        }
    }
}
