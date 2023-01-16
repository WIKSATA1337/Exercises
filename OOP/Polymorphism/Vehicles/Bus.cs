using System;

namespace Vehicles
{
    public class Bus : Vehicle
    {
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public override void Drive(double distance)
        {
            double consumption = distance * (FuelConsumption + 1.4);

            if (consumption <= FuelQuantity)
            {
                FuelQuantity -= consumption;
                Console.WriteLine($"{GetType().Name} travelled {distance} km");
                return;
            }
            Console.WriteLine($"{GetType().Name} needs refueling");
        }
        public void DriveEmpty(double distance)
        {
            base.Drive(distance);
        }
    }
}
