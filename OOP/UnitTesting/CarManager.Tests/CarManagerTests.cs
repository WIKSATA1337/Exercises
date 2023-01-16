namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CarManagerTests
    {
        private Car car;
        private string make = "Audi";
        private string model = "A4";
        private double fuelConsumption = 4;
        private double fuelCapacity = 10;

        [SetUp]
        public void Setup()
        {
            car = new Car(make, model, fuelConsumption, fuelCapacity);
        }

        [Test]
        public void ConstructorShouldSetProperties()
        {
            Assert.AreEqual(make, car.Make);
            Assert.AreEqual(model, car.Model);
            Assert.AreEqual(fuelConsumption, car.FuelConsumption);
            Assert.AreEqual(fuelCapacity, car.FuelCapacity);
            Assert.AreEqual(0, car.FuelAmount);
        }

        [Test]
        public void Make_ShouldThrowException_OnEmptyOrNull()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                car = new Car("", model, fuelConsumption, fuelCapacity);
            });

            Assert.Throws<ArgumentException>(() =>
            {
                car = new Car(null, model, fuelConsumption, fuelCapacity);
            });
        }

        [Test]
        public void Model_ShouldThrowException_OnEmptyOrNull()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                car = new Car(make, "", fuelConsumption, fuelCapacity);
            });

            Assert.Throws<ArgumentException>(() =>
            {
                car = new Car(make, null, fuelConsumption, fuelCapacity);
            });
        }

        [Test]
        public void FuelConsumption_ShouldThrowException_OnZeroOrNegative()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                car = new Car(make, model, 0, fuelCapacity);
            });

            Assert.Throws<ArgumentException>(() =>
            {
                car = new Car(make, model, -1, fuelCapacity);
            });
        }

        [Test]
        public void FuelAmount_ShouldThrowException_OnZeroOrNegative()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                car = new Car(make, model, fuelConsumption, 0);
            });

            Assert.Throws<ArgumentException>(() =>
            {
                car = new Car(make, model, fuelConsumption, -1);
            });
        }

        [Test]
        public void Refuel_ShouldThrowException_OnZeroOrNegative()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                car.Refuel(0);
            });

            Assert.Throws<ArgumentException>(() =>
            {
                car.Refuel(-1);
            });
        }

        [Test]
        public void Refuel_ShouldWorkCorrectly()
        {
            double fuelToRefuel = 5;

            double oldFuelAmount = car.FuelAmount;

            car.Refuel(fuelToRefuel);

            Assert.AreEqual(oldFuelAmount + fuelToRefuel, car.FuelAmount);
        }

        [Test]
        public void Refuel_ShouldNotOverflowTheCapacity()
        {
            double fuelToRefuel = 20;

            car.Refuel(fuelToRefuel);

            Assert.AreEqual(car.FuelCapacity, car.FuelAmount);
        }

        [Test]
        public void Drive_ShouldWorkCorrectly()
        {
            double distanceToDrive = 100;
            double expectedFuelNeeded = (distanceToDrive / 100) * car.FuelConsumption;
            double refuelAmount = 10;
            double expectedFuelAmountAtEnd = (refuelAmount + car.FuelAmount) - expectedFuelNeeded;

            car.Refuel(refuelAmount);

            car.Drive(distanceToDrive);

            Assert.AreEqual(expectedFuelAmountAtEnd, car.FuelAmount);
        }

        [Test]
        public void Drive_ShouldThrowException_OnTooBigDistance()
        {
            double bigDistance = 50000;
            double refuelAmount = 7;

            car.Refuel(refuelAmount);

            Assert.Throws<InvalidOperationException>(() =>
            {
                car.Drive(bigDistance);
            });
        }
    }
}