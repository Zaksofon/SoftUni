using System;
using System.Linq;
using NUnit.Framework;

namespace Tests
{
    public class CarTests
    {
        private Car car;
        [SetUp]
        public void Setup()
        {
           car = new Car("Make", "Model", 10, 100);
        }

        [Test]
        [TestCase("", "Model", 10, 100)]
        [TestCase(null, "Model", 10, 100)]
        [TestCase("Make", "", 10, 100)]
        [TestCase("Make", null, 10, 100)]
        [TestCase("Make", "Model", 0, 100)]
        [TestCase("Make", "Model", -5, 100)]
        [TestCase("Make", "Model", 10, 0)]
        [TestCase("Make", "Model", 10, -100)]
        public void Ctor_ThrowsException_WhenDataIsInvalid(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));
        }

        [Test]
        public void Ctor_SetsInitialValues_WhenArgumentsAreValid()
        {
            string make = "Make";
            string model = "Model";
            double fuelConsumption = 10.0;
            double fuelCapacity = 100.0;

            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            Assert.That(car.Make, Is.EqualTo(make));
            Assert.That(car.Model, Is.EqualTo(model));
            Assert.That(car.FuelConsumption, Is.EqualTo(fuelConsumption));
            Assert.That(car.FuelCapacity, Is.EqualTo(fuelCapacity));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-10)]
        public void Refuel_ThrowsException_WhenFuelAmountIsZeroOrNegative(double fuel)
        {
            Assert.Throws<ArgumentException>(() => car.Refuel(fuel));
        }

        [Test]
        public void Refuel_IncreasesFuelAmount_WhenFuelAmountIsValid()
        {
            double fuelToRefuel = car.FuelCapacity / 2;
            car.Refuel(fuelToRefuel);
            Assert.That(car.FuelAmount, Is.EqualTo(fuelToRefuel));
        }

        [Test]
        public void Refuel_SetsFuelAmountToFuelCapacity_WhenFuelCapacityIsExceeded()
        {
            double fuelToRefuel = car.FuelCapacity * 1.2;
            car.Refuel(fuelToRefuel);
            Assert.That(car.FuelAmount, Is.EqualTo(car.FuelCapacity));
        }

        [Test]
        public void Drive_ThrowsException_WhenNotEnoughFuelForTheDistnce()
        {
            Assert.Throws<InvalidOperationException>(() => car.Drive(10));
        }

        [Test]
        public void Drive_DecreasesFuelAmount_WhenFuelAmountIsValid()
        {
            double fuelToRefuel = car.FuelCapacity / 2;
            car.Refuel(fuelToRefuel);
            car.Drive(450);
            Assert.That(car.FuelAmount, Is.LessThan(fuelToRefuel));
        }
    }
}