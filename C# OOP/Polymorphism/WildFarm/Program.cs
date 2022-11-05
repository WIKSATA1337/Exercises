using System;
using System.Collections.Generic;
using System.Linq;
using WildFarm.Abstractions.Animals;
using WildFarm.Abstractions.Animals.Birds;
using WildFarm.Abstractions.Animals.Mammals;
using WildFarm.Abstractions.Animals.Mammals.Felines;
using WildFarm.Abstractions.Foods;

namespace WildFarm
{
    public class Program
    {
        static void Main()
        {
            List<Food> foods = new List<Food>();
            List<Animal> animals = new List<Animal>();

            int lineCount = 0;

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] splittedCommand = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (lineCount % 2 == 0)
                {
                    // Animal

                    if (splittedCommand.Length == 5)
                    {
                        if (splittedCommand[0] == "Cat")
                        {
                            animals.Add(new Cat(splittedCommand[1], double.Parse(splittedCommand[2]),
                                0, splittedCommand[3], splittedCommand[4]));
                        }
                        else if (splittedCommand[0] == "Tiger")
                        {
                            animals.Add(new Tiger(splittedCommand[1], double.Parse(splittedCommand[2]),
                                0, splittedCommand[3], splittedCommand[4]));
                        }
                    }
                    else
                    {
                        if (splittedCommand[0] == "Mouse")
                        {
                            animals.Add(new Mouse(splittedCommand[1], double.Parse(splittedCommand[2]),
                                0, splittedCommand[3]));
                        }
                        else if (splittedCommand[0] == "Dog")
                        {
                            animals.Add(new Dog(splittedCommand[1], double.Parse(splittedCommand[2]),
                                0, splittedCommand[3]));
                        }
                        else if (splittedCommand[0] == "Hen")
                        {
                            animals.Add(new Hen(splittedCommand[1], double.Parse(splittedCommand[2]),
                                0, double.Parse(splittedCommand[3])));
                        }
                        else if(splittedCommand[0] == "Owl")
                        {
                            animals.Add(new Owl(splittedCommand[1], double.Parse(splittedCommand[2]),
                                0, double.Parse(splittedCommand[3])));
                        }
                    }
                }
                else
                {
                    // Food
                    if (splittedCommand[0] == "Vegetable")
                    {
                        foods.Add(new Vegetable(int.Parse(splittedCommand[1])));
                    }
                    else if (splittedCommand[0] == "Fruit")
                    {
                        foods.Add(new Fruit(int.Parse(splittedCommand[1])));
                    }
                    else if (splittedCommand[0] == "Meat")
                    {
                        foods.Add(new Meat(int.Parse(splittedCommand[1])));
                    }
                    else if (splittedCommand[0] == "Seeds")
                    {
                        foods.Add(new Seeds(int.Parse(splittedCommand[1])));
                    }

                    // Feed
                    var currentAnimal = animals.Last();
                    currentAnimal.Feed(foods.Last());
                }

                lineCount++;
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal.ToString());
            }
        }
    }
}
