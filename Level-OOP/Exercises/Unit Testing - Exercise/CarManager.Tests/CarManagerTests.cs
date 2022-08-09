namespace CarManager.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class CarManagerTests
    {
        [Test]
        public void ConstructorShouldSetMakeProperty()
        {
            const string carMake = "test";

            var car = new Car(carMake, "test", 1, 1);

            Assert.That(carMake, Is.EqualTo(car.Make));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void ConstructorShouldThrowExceptionWhenMakePropertyIsNullOrEmpty(string carName)
        {
            Assert.Throws<ArgumentException>(
                () => new Car(carName, "model", 1, 1),
                "Make cannot be null or empty!");
        }

        [Test]
        public void ConstructorShouldSetModelProperty()
        {
            const string carModel = "test";

            var car = new Car("test", carModel, 1, 1);

            Assert.That(carModel, Is.EqualTo(car.Model));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void ConstructorShouldThrowExceptionWhenModelPropertyIsNullOrEmpty(string carModel)
        {
            Assert.Throws<ArgumentException>(
                () => new Car("test", carModel, 1, 1),
                "Model cannot be null or empty!");
        }

        [Test]
        public void ConstructorShouldSetPropertyFuelConsumption()
        {
            const double CarFuelConsumption = 1.8;

            var car = new Car("test", "test", CarFuelConsumption, 1);

            Assert.That(CarFuelConsumption,
                Is.EqualTo(car.FuelConsumption));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-5)]
        public void ConstructorShouldThrowExceptionWhenFuelConsumptionPropertyIsZeroOrLess(double fuelConsumption)
        {
            Assert.Throws<ArgumentException>(
                () => new Car("test", "test", fuelConsumption, 1),
                "Fuel consumption cannot be zero or negative!");
        }

        [Test]
        public void ConstructorShouldSetFuelAmountPropertyToZero()
        {
            var car = new Car("test", "test", 1.1, 1);

            Assert.That(0, Is.EqualTo(car.FuelAmount));
        }

        [Test]
        public void ConstructorShouldSetFuelCapacityProperty()
        {
            const double CarFuelCapacity = 1.9;

            var car = new Car("test", "test", 1, CarFuelCapacity);

            Assert.That(CarFuelCapacity, Is.EqualTo(car.FuelCapacity));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-5.1)]
        public void ConstructorShouldThrowExceptionWhenFuelCapacityPropertyIsZeroOrLess(double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(
                () => new Car("test", "test", 1, fuelCapacity),
                "Fuel capacity cannot be zero or negative!");
        }

        [Test]
        [TestCase(0)]
        [TestCase(-2)]
        public void RefuelMethodShouldThrowExceptionWhenMethodParameterIsZerOrLess(double methodParam)
        {
            var car = new Car("test", "test", 1, 1);

            Assert.Throws<ArgumentException>(
                () => car.Refuel(methodParam),
                "Fuel amount cannot be zero or negative!");
        }

        [Test]
        [TestCase(9)]
        [TestCase(10)]
        public void RefuelMethodShouldIncreaseFuelAmount(double amount)
        {
            var car = new Car("test", "test", 1, 10);

            car.Refuel(amount);

            Assert.That(car.FuelAmount, Is.EqualTo(amount));
        }

        [Test]
        public void RefuelMethodShouldSetFuelAmountEqualToFuelCapacityWhenOverRefuel()
        {
            var car = new Car("test", "test", 1, 5);

            car.Refuel(7);

            Assert.That(car.FuelAmount, Is.EqualTo(car.FuelCapacity));
        }

        [Test]
        [TestCase(6000)]
        public void DriveOperationShouldThrowInvalidOperationExceptionInAttemptToDriveABiggerDistanceWhenFuelIsNotEnough(double distance)
        {
            var car = new Car("test", "test", 6.5, 60);

            car.Refuel(60);

            Assert.That(() => car.Drive(distance), Throws.InvalidOperationException
                                                              .With.Message
                                                              .EqualTo("You don't have enough fuel to drive!"));
        }

        [Test]
        [TestCase(10)]
        public void DriveOperationShouldDecrementFuelAmountCorrectly(double distance)
        {
            var car = new Car("test", "test", 6.5, 60);

            car.Refuel(60);
            car.Drive(distance);
            double expectedFuelAmount = 59.35;

            Assert.AreEqual(expectedFuelAmount, car.FuelAmount);
        }
    }
}