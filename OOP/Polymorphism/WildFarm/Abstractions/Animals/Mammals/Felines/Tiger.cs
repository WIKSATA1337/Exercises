using System;
using WildFarm.Abstractions.Foods;

namespace WildFarm.Abstractions.Animals.Mammals.Felines
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, int foodEaten, string livingRegion, string breed) : base(name, weight, foodEaten, livingRegion, breed)
        {
        }

        public override void AskForFood()
        {
            Console.WriteLine("ROAR!!!");
        }

        public override void Feed(Food food)
        {
            if (food is Meat)
            {
                FoodEaten += food.Quantity;
                Weight += 1.00 * food.Quantity;
                return;
            }

            Console.WriteLine($"{GetType().Name} does not eat {food.GetType().Name}!");
        }
    }
}
