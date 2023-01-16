using System;
using System.Linq;

namespace Vehicles
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] carInput = Console.ReadLine()
                .Split()
                .Skip(1)
                .ToArray();
            Car car = new Car(double.Parse(carInput[0]), double.Parse(carInput[1]), double.Parse(carInput[2]));

            string[] truckInput = Console.ReadLine()
                .Split()
                .Skip(1)
                .ToArray();
            Truck truck = new Truck(double.Parse(truckInput[0]), double.Parse(truckInput[1]), double.Parse(truckInput[2]));

            string[] busInput = Console.ReadLine()
                .Split()
                .Skip(1)
                .ToArray();
            Bus bus = new Bus(double.Parse(busInput[0]), double.Parse(busInput[1]), double.Parse(busInput[2]));

            int commandsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandsCount; i++)
            {
                string[] command = Console.ReadLine()
                    .Split();

                if (command[1] == "Car")
                {
                    if (command[0] == "Drive")
                    {
                        car.Drive(double.Parse(command[2]));
                    }
                    else
                    {
                        car.Refuel(double.Parse(command[2]));
                    }
                }
                else if(command[1] == "Truck")
                {
                    if (command[0] == "Drive")
                    {
                        truck.Drive(double.Parse(command[2]));
                    }
                    else
                    {
                        truck.Refuel(double.Parse(command[2]));
                    }
                }
                else
                {
                    if (command[0] == "Drive")
                    {
                        bus.Drive(double.Parse(command[2]));
                    }
                    else if (command[0] == "DriveEmpty")
                    {
                        bus.DriveEmpty(double.Parse(command[2]));
                    }
                    else
                    {
                        bus.Refuel(double.Parse(command[2]));
                    }
                }
            }

            Console.WriteLine(car.ToString());
            Console.WriteLine(truck.ToString());
            Console.WriteLine(bus.ToString());
        }
    }
}
