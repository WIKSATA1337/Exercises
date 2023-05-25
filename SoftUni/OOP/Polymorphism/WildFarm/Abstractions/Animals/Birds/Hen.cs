using WildFarm.Abstractions.Foods;

namespace WildFarm.Abstractions.Animals.Birds
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, int foodEaten, double wingSize) : base(name, weight, foodEaten, wingSize)
        {
        }

        public override void AskForFood()
        {
            System.Console.WriteLine("Cluck");
        }

        public override void Feed(Food food)
        {
            FoodEaten += food.Quantity;
            Weight += 0.35 * food.Quantity;
        }
    }
}
