using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();

            int carsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < carsCount; i++)
            {
                string[] input = Console.ReadLine()
                    .Split();

                var model = input[0];
                var engine = new Engine(int.Parse(input[1]), int.Parse(input[2]));
                var cargo = new Cargo(input[4], int.Parse(input[3]));
                var tireOne = new Tire(int.Parse(input[6]), double.Parse(input[5]));
                var tireTwo = new Tire(int.Parse(input[8]), double.Parse(input[7]));
                var tireThree = new Tire(int.Parse(input[10]), double.Parse(input[9]));
                var tireFour = new Tire(int.Parse(input[12]), double.Parse(input[11]));

                var tiresArr = new Tire[] { tireOne, tireTwo, tireThree, tireFour };

                cars.Add(new Car(model, engine, cargo, tiresArr));
            }

            string searchType = Console.ReadLine();

            if (searchType == "fragile")
            {
                var resultList = cars.Where(car => car.Cargo.Type == "fragile").ToList();

                foreach (var car in resultList)
                {
                    foreach (var tire in car.Tires)
                    {
                        if (tire.Pressure < 1)
                        {
                            Console.WriteLine(car.Model);
                            break;
                        }
                    }
                }
            }
            else
            {
                var resultList = cars.Where(car => car.Cargo.Type == "flammable")
                    .Where(car => car.Engine.Power > 250)
                    .ToList();

                foreach (var car in resultList)
                {
                    Console.WriteLine(car.Model);
                }
            }
        }
    }
}
