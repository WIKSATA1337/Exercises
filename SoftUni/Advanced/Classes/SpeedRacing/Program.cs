using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;

namespace SpeedRacing
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();

            int carsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < carsCount; i++)
            {
                string[] currentCar = Console.ReadLine()
                .Split();

                cars.Add(new Car(currentCar[0], double.Parse(currentCar[1]), double.Parse(currentCar[2])));
            }

            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                var cmdInfo = command.Split();

                var findCar = cars.Find(c => c.Model == cmdInfo[1]);

                findCar.Move(int.Parse(cmdInfo[2]));
            }

            PrintCars(cars);
        }

        private static void PrintCars(List<Car> cars)
        {
            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:F2} {car.TravelledDistance}");
            }
        }
    }
}
