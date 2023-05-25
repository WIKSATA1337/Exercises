using System;
using WildFarm.Abstractions.Foods;

namespace WildFarm.Abstractions.Animals.Mammals
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, int foodEaten, string livingRegion) : base(name, weight, foodEaten, livingRegion)
        {
        }

        public override void AskForFood()
        {
            Console.WriteLine("Woof!");
        }

        public override void Feed(Food food)
        {
            if (food is Meat)
            {
                FoodEaten += food.Quantity;
                Weight += 0.40 * food.Quantity;
                return;
            }

            Console.WriteLine($"{GetType().Name} does not eat {food.GetType().Name}!");
        }
    }
}
