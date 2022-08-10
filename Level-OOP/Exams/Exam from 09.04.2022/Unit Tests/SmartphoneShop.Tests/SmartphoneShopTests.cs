using System;
using NUnit.Framework;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
        [Test]
        public void ConstructorShouldSetCapacity()
        {
            //Arrange
            Shop shop = new Shop(4);

            //Assert
            Assert.AreEqual(4, shop.Capacity);
        }

        [Test]
        public void ConstructorShouldThrowExceptionForNegativeCapacity()
        {
            Assert.Throws<ArgumentException>(() => new Shop(-1));
        }

        [Test]
        public void ShopShouldHaveCorrectCount()
        {
            Shop shop = new Shop(5);
            shop.Add(new Smartphone("Alcatel", 0));
            shop.Add(new Smartphone("Sony", 0));
            shop.Add(new Smartphone("Samsung", 0));
            shop.Add(new Smartphone("Samsung2", 0));

            Assert.AreEqual(4, shop.Count);
        }

        [Test]
        public void ShopShouldHaveCountOfZero()
        {
            Shop shop = new Shop(1);

            Assert.AreEqual(0, shop.Count);
        }

        [Test]
        public void AddMethodShouldThrowExceptionWhenTwoIdenticalPhones()
        {
            //Arrange
            Shop shop = new Shop(10);

            //Act
            shop.Add(new Smartphone("Samsung", 5));

            //Assert
            Assert.Throws<InvalidOperationException>
                (() => shop.Add(new Smartphone("Samsung", 5)));
        }

        [Test]
        public void AddMethodShouldThrowExceptionWhenShopCapacityEqualsPhonesCount()
        {
            Shop shop = new Shop(2);

            shop.Add(new Smartphone("Samsung", 0));
            shop.Add(new Smartphone("Alcatel", 0));

            Assert.Throws<InvalidOperationException>
                (() => shop.Add(new Smartphone("Sony", 0)));
        }

        [Test]
        public void AddMethodShouldWorkCorrectly()
        {
            Shop shop = new Shop(3);

            shop.Add(new Smartphone("Sony", 0));

            Assert.AreEqual(1, shop.Count);
        }

        [Test]
        public void RemoveMethodShouldWorkCorrectly()
        {
            Shop shop = new Shop(4);

            shop.Add(new Smartphone("Sony", 0));
            shop.Add(new Smartphone("Nokia", 0));
            shop.Add(new Smartphone("Alcatel", 0));

            shop.Remove("Sony");

            Assert.AreEqual(2, shop.Count);
        }

        [Test]
        public void RemoveMethodShouldThrowExceptionWhenNoPhoneFound()
        {
            Shop shop = new Shop(3);

            shop.Add(new Smartphone("IPhone", 4));

            Assert.Throws<InvalidOperationException>
                (() => shop.Remove("Nokia"));
        }

        [Test]
        public void TestPhoneMethodShouldThrowExceptionWhenNoPhoneFound()
        {
            Shop shop = new Shop(3);
            shop.Add(new Smartphone("Samsung", 0));

            Assert.Throws<InvalidOperationException>
                (() => shop.TestPhone("Nokia", 5));
        }

        [Test]
        public void TestPhoneMethodShouldThrowExceptionWhenCurrentBatteryUsageLessThanBatteryUsageParam()
        {
            Shop shop = new Shop(2);

            shop.Add(new Smartphone("Nokia", 2));

            Assert.Throws<InvalidOperationException>
                (() => shop.TestPhone("Nokia", 5));
        }

        [Test]
        public void TestPhoneMethodShouldWorkCorrectly()
        {
            Shop shop = new Shop(2);
            Smartphone currentPhone = new Smartphone("Samsung", 3);
            shop.Add(currentPhone);
            shop.TestPhone("Samsung", 2);

            Assert.AreEqual(1, currentPhone.CurrentBateryCharge);
        }

        [Test]
        public void ChargePhoneMethodShouldThrowExceptionWhenNoPhoneFound()
        {
            Shop shop = new Shop(3);

            shop.Add(new Smartphone("Nokia", 0));

            Assert.Throws<InvalidOperationException>
                (() => shop.ChargePhone("Samsung"));
        }

        [Test]
        public void ChargePhoneMethodShouldWorkCorrectly()
        {
            Shop shop = new Shop(3);

            Smartphone sp = new Smartphone("Samsung", 5);
            shop.Add(sp);

            shop.ChargePhone("Samsung");

            Assert.AreEqual(5, sp.MaximumBatteryCharge);
        }
    }
}