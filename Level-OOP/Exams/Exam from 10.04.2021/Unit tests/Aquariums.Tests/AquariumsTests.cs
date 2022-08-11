namespace Aquariums.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class AquariumsTests
    {
        [Test]
        public void ConstructorShouldInitializeCollection()
        {
            //Arrange
            var aq = new Aquarium("Name", 5);

            //Act & Assert
            Assert.IsNotNull(aq.Count);
        }

        [Test]
        public void ConstructorShouldSetName()
        {
            //Arrange
            var aq = new Aquarium("UnderWater", 5);

            //Act & Assert
            Assert.AreEqual("UnderWater", aq.Name);
        }

        [Test]
        public void ConstructorShouldThrowExceptionWhenNullName()
        {
            //Arrange, Act & Assert
            Assert.Throws<ArgumentNullException>(
                () => new Aquarium(null, 5));
        }

        [Test]
        public void ConstructorShouldThrowExceptionWhenEmptyName()
        {
            //Arrange, Act & Assert
            Assert.Throws<ArgumentNullException>(
                () => new Aquarium(string.Empty, 5));
        }

        [Test]
        public void ConstructorShouldSetCapacity()
        {
            //Arrange
            var aq = new Aquarium("Name", 5);

            //Act & Assert
            Assert.AreEqual(5, aq.Capacity);
        }

        [Test]
        public void ConstructorShouldThrowExceptionWhenCapacityIsBelowZero()
        {
            //Arrange, Act & Assert
            Assert.Throws<ArgumentException>(
                () => new Aquarium("Name", -5));
        }

        [Test]
        public void ConstructorShouldSetValidCount()
        {
            //Arrange
            var aq = new Aquarium("Name", 5);

            //Act
            aq.Add(new Fish("Fish1"));
            aq.Add(new Fish("Fish2"));
            aq.Add(new Fish("Fish3"));

            //Arrange
            Assert.AreEqual(3, aq.Count);
        }

        [Test]
        public void ConstructorShouldSetValidCountOfZero()
        {
            //Arrange
            var aq = new Aquarium("Name", 5);

            //Act & Assert
            Assert.AreEqual(0, aq.Count);
        }

        [Test]
        public void AddMethodShouldThrowExceptionWhenFishCountIsEqualToAquariumCapacity()
        {
            //Arrange
            var aq = new Aquarium("Name", 3);

            //Act
            aq.Add(new Fish("Name1"));
            aq.Add(new Fish("Name2"));
            aq.Add(new Fish("Name3"));

            //Assert
            Assert.Throws<InvalidOperationException>(
                () => aq.Add(new Fish("Name")));
        }

        [Test]
        public void RemoveMethodShoulThrowExceptionWhenFishIsNull()
        {
            //Arrange
            var aq = new Aquarium("Name", 3);

            //Act
            aq.Add(new Fish("Name1"));
            aq.Add(new Fish("Name2"));

            //Assert
            Assert.Throws<InvalidOperationException>(
                () => aq.RemoveFish("MissingName"));
        }

        [Test]
        public void RemoveMethodShouldWorkCorrectlyByDecreasingAquariumFishCount()
        {
            //Arrange
            var aq = new Aquarium("Name", 5);

            //Act
            aq.Add(new Fish("Name1"));
            aq.Add(new Fish("Name2"));
            aq.Add(new Fish("Name3"));

            aq.RemoveFish("Name2");
            aq.RemoveFish("Name3");

            //Assert
            Assert.AreEqual(1, aq.Count);
        }

        [Test]
        public void SellFishMethodShouldThrowExceptionWhenFishToSellIsNull()
        {
            //Arrange
            var aq = new Aquarium("Name", 5);

            //Act
            aq.Add(new Fish("Name1"));
            aq.Add(new Fish("Name2"));
            aq.Add(new Fish("Name3"));

            //Assert
            Assert.Throws<InvalidOperationException>(
                () => aq.SellFish("MissingName"));
        }

        [Test]
        public void SellFishMethodShouldChangeFishAvailablePropToFalse()
        {
            //Arrange
            var aq = new Aquarium("Name", 5);
            var fish1 = new Fish("Name1");
            var fish2 = new Fish("Name2");
            var fish3 = new Fish("Name3");

            //Act
            aq.Add(fish1);
            aq.Add(fish2);
            aq.Add(fish3);

            aq.SellFish("Name2");

            //Assert
            Assert.False(fish2.Available);
        }

        [Test]
        public void SellFishMethodShouldReturnCorrectFish()
        {
            //Arrange
            var aq = new Aquarium("Name", 5);
            var fish1 = new Fish("Name1");
            var fish2 = new Fish("Name2");
            var fish3 = new Fish("Name3");

            //Act
            aq.Add(fish1);
            aq.Add(fish2);
            aq.Add(fish3);

            //Assert
            Assert.AreEqual(fish2,
                aq.SellFish("Name2"));
        }

        [Test]
        public void ReportMethodShouldReturnCorrectOutput()
        {
            //Arrange
            var aq = new Aquarium("Name", 5);

            var fish1 = new Fish("Name1");
            var fish2 = new Fish("Name2");
            var fish3 = new Fish("Name3");

            //Act
            aq.Add(fish1);
            aq.Add(fish2);
            aq.Add(fish3);

            //Assert
            var collection = $"{fish1.Name}, {fish2.Name}, {fish3.Name}";

            Assert.AreEqual(
                $"Fish available at {aq.Name}: {collection}", aq.Report());
        }
    }
}
