using System;

namespace Vehicles
{
    public abstract class Vehicle
    {
        private double fuelQuantity;

        public Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            TankCapacity = tankCapacity;
            FuelConsumption = fuelConsumption;
            FuelQuantity = fuelQuantity;
        }

        public double FuelQuantity
        {
            get { return fuelQuantity; }
            set 
            {
                if (value > TankCapacity)
                {
                    fuelQuantity = 0;
                }
                else
                {
                    fuelQuantity = value;
                }
            }
        }
        public double FuelConsumption { get; set; }
        public double TankCapacity { get; set; }

        public virtual void Drive(double distance)
        {
            double distanceToTravel;

            if (FuelConsumption < 1)
            {
                distanceToTravel = distance + (distance * FuelConsumption);
            }
            else
            {
                distanceToTravel = distance * FuelConsumption;
            }

            if (distanceToTravel <= FuelQuantity)
            {
                FuelQuantity -= distanceToTravel;
                Console.WriteLine($"{GetType().Name} travelled {distance} km");
                return;
            }
            Console.WriteLine($"{GetType().Name} needs refueling");
        }
        public virtual void Refuel(double fuel)
        {
            if (fuel <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
                return;
            }

            if (fuel > TankCapacity)
            {
                Console.WriteLine($"Cannot fit {fuel} fuel in the tank");
                return;
            }

            FuelQuantity += fuel;
        }
        public override string ToString()
        {
            return $"{GetType().Name}: {FuelQuantity:F2}";
        }
    }
}
