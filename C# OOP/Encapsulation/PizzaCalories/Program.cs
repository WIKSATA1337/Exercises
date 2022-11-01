using System;
using System.Data;
using System.Linq;

namespace PizzaCalories
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] pizzaName = Console.ReadLine()
                .Split()
                .Skip(1)
                .ToArray();

            string[] doughInfo = Console.ReadLine()
                .Split()
                .Skip(1)
                .ToArray();

            try
            {
                Dough dough = new Dough(doughInfo[0], doughInfo[1], double.Parse(doughInfo[2]));

                Pizza pizza = new Pizza(pizzaName[0], dough);

                string command;
                while ((command = Console.ReadLine()) != "END")
                {
                    string[] toppingInfo = command
                        .Split()
                        .Skip(1)
                        .ToArray();

                    Topping topping = new Topping(toppingInfo[0], double.Parse(toppingInfo[1]));

                    pizza.AddTopping(topping);
                }

                Console.WriteLine($"{pizza.Name} - {pizza.GetTotalCalories():F2} Calories.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }
    }
}
