using System;
using System.Collections.Generic;
using System.Text;

namespace CarSalesman
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();

            int enginesCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < enginesCount; i++)
            {
                string[] input = Console.ReadLine()
                    .Split();


                AddEngine(input, engines);
            }

            int carsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < carsCount; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                AddCar(input, cars, engines);
            }

            PrintResult(cars);
        }

        private static void PrintResult(List<Car> cars)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var car in cars)
            {   
                sb.Append(car.ToString());
            }

            Console.Write(sb.ToString().Trim());
        }

        private static void AddCar(string[] input, List<Car> cars, List<Engine> engines)
        {
            var engineFound = engines.Find(engine => engine.Model == input[1]);

            if (input.Length == 3)
            {
                if (char.IsDigit(input[2][0]))
                {
                    cars.Add(new Car(input[0], engineFound, int.Parse(input[2])));
                }
                else
                {
                    cars.Add(new Car(input[0], engineFound, input[2]));
                }
            }
            else if (input.Length == 4)
            {
                cars.Add(new Car(input[0], engineFound, int.Parse(input[2]), input[3]));
            }
            else
            {
                cars.Add(new Car(input[0], engineFound));
            }
        }

        private static void AddEngine(string[] input, List<Engine> engines)
        {
            if (input.Length == 2)
            {
                engines.Add(new Engine(input[0], int.Parse(input[1])));
            }
            else if (input.Length == 3)
            {
                if (int.TryParse(input[2], out int displacement))
                {
                    engines.Add(new Engine(input[0], int.Parse(input[1]), displacement));
                }
                else
                {
                    engines.Add(new Engine(input[0], int.Parse(input[1]), input[2]));
                }
            }
            else
            {
                engines.Add(new Engine(input[0], int.Parse(input[1]), int.Parse(input[2]), input[3]));
            }
        }
    }
}
