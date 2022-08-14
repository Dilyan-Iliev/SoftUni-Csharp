using NUnit.Framework;
using System;
using System.ComponentModel;

namespace PlanetWars.Tests
{
    public class Tests
    {
        [TestFixture]
        public class PlanetWarsTests
        {
            private Planet planet;

            [SetUp]
            public void Initializer()
            {
                this.planet = new Planet("Name", 5);
            }

            [Test]
            public void ConstructorShouldInitializeCollection()
            {
                Assert.That(planet.Weapons.Count, Is.Not.Null);
            }

            [Test]
            public void ConstructorShouldInitializeCollectionWithZeroElements()
            {
                Assert.That(planet.Weapons.Count, Is.EqualTo(0));
            }

            [Test]
            public void ConstructorShouldInitializeName()
            {
                Assert.That(planet.Name, Is.EqualTo("Name"));
            }

            [Test]
            public void ConstructorShouldInitializeBudget()
            {
                Assert.That(planet.Budget, Is.EqualTo(5));
            }

            [Test]
            [TestCase(null)]
            [TestCase("")]
            public void ConstructorShouldThrowExceptionWhenInvalidName(string name)
            {
                Assert.Throws<ArgumentException>(
                    () => new Planet(name, 5),
                    "Invalid planet Name");
            }

            [Test]
            public void ConstructorShouldThrowExceptionWhenInvalidBudget()
            {
                Assert.Throws<ArgumentException>(
                    () => new Planet("Name", -1));
            }

            [Test]
            public void ProfitMethodShouldIncreaseBudget()
            {
                planet.Profit(5);

                Assert.That(planet.Budget, Is.EqualTo(10));
            }

            [Test]
            public void SpendFundsShouldDecreaseBudget()
            {
                planet.SpendFunds(3);

                Assert.That(planet.Budget, Is.EqualTo(2));
            }

            [Test]
            public void SpendFundsShouldDecreaseBudgetToZero()
            {
                planet.SpendFunds(5);

                Assert.That(planet.Budget, Is.EqualTo(0));
            }

            [Test]
            public void SpendFundsShouldThrowExceptionWhenAmountIsBiggerThanBudget()
            {
                Assert.Throws<InvalidOperationException>(
                    () => planet.SpendFunds(6),
                    "Not enough funds to finalize the deal.");
            }

            [Test]
            public void AddWeaponShouldAddWeaponToCollection()
            {
                var weapon = new Weapon("Name", 10, 4);

                planet.AddWeapon(weapon);

                Assert.AreEqual(1, planet.Weapons.Count);
            }

            [Test]
            public void AddWeaponShouldThrowExceptionWhenDuplicatedWeapon()
            {
                var weapon = new Weapon("Name", 10, 4);
                planet.AddWeapon(weapon);

                Assert.Throws<InvalidOperationException>(
                    () => planet.AddWeapon(new Weapon("Name", 5, 5)));
            }

            [Test]
            public void RemoveWeaponShouldRemoveWeapon()
            {
                var weapon = new Weapon("Name", 5, 5);
                var weapon2 = new Weapon("Name2", 5, 5);

                planet.AddWeapon(weapon);
                planet.AddWeapon(weapon2);

                planet.RemoveWeapon("Name2");

                Assert.That(planet.Weapons.Count, Is.EqualTo(1));
            }

            [Test]
            public void UpgradeWeaponShouldThrowExceptionWhenNoWeaponFound()
            {
                Assert.Throws<InvalidOperationException>(
                    () => planet.UpgradeWeapon("customWeaponName"));
            }

            [Test]
            public void UpgradeWeaponShouldWorkCorrectly()
            {
                var weapon = new Weapon("WeaponName", 5, 5);
                planet.AddWeapon(weapon);
                planet.UpgradeWeapon("WeaponName");

                Assert.That(weapon.DestructionLevel, Is.EqualTo(6));
            }

            [Test]
            public void DestructOpponentShouldThrowExceptionWhenOpponentIsStrongerThanMe()
            {
                var weapon1 = new Weapon("name", 5, 4);
                var weapon2 = new Weapon("name2", 5, 5);
                var weapon3 = new Weapon("name3", 5, 10);

                planet.AddWeapon(weapon1);
                planet.AddWeapon(weapon2);
                planet.AddWeapon(weapon3);

                var opponentPlanet = new Planet("Enemy", 4);
                var oppWeapon1 = new Weapon("Name", 5, 10);
                var oppWeapon2 = new Weapon("Name2", 5, 20);
                var oppWeapon3 = new Weapon("Name3", 5, 30);

                opponentPlanet.AddWeapon(oppWeapon1);
                opponentPlanet.AddWeapon(oppWeapon2);
                opponentPlanet.AddWeapon(oppWeapon3);

                Assert.Throws<InvalidOperationException>(
                    () => planet.DestructOpponent(opponentPlanet));
            }

            [Test]
            public void DestructOpponentShouldThrowExceptionWhenOpponentIsEqualToMe()
            {
                var weapon1 = new Weapon("name", 5, 4);
                var weapon2 = new Weapon("name2", 5, 5);
                var weapon3 = new Weapon("name3", 5, 10);

                planet.AddWeapon(weapon1);
                planet.AddWeapon(weapon2);
                planet.AddWeapon(weapon3);

                var opponentPlanet = new Planet("Enemy", 4);
                var oppWeapon1 = new Weapon("Name", 5, 4);
                var oppWeapon2 = new Weapon("Name2", 5, 5);
                var oppWeapon3 = new Weapon("Name3", 5, 10);

                opponentPlanet.AddWeapon(oppWeapon1);
                opponentPlanet.AddWeapon(oppWeapon2);
                opponentPlanet.AddWeapon(oppWeapon3);

                Assert.Throws<InvalidOperationException>(
                    () => planet.DestructOpponent(opponentPlanet));
            }

            [Test]
            public void DestructOpponentShouldReturnCorrectMessage()
            {
                var weapon1 = new Weapon("name", 5, 40);
                var weapon2 = new Weapon("name2", 5, 50);
                var weapon3 = new Weapon("name3", 5, 10);

                planet.AddWeapon(weapon1);
                planet.AddWeapon(weapon2);
                planet.AddWeapon(weapon3);

                var opponentPlanet = new Planet("Enemy", 4);
                var oppWeapon1 = new Weapon("Name", 5, 4);
                var oppWeapon2 = new Weapon("Name2", 5, 5);
                var oppWeapon3 = new Weapon("Name3", 5, 10);

                opponentPlanet.AddWeapon(oppWeapon1);
                opponentPlanet.AddWeapon(oppWeapon2);
                opponentPlanet.AddWeapon(oppWeapon3);

                string expectedMessage = "Enemy is destructed!";

                Assert.That(expectedMessage, Is.EqualTo(planet.DestructOpponent(opponentPlanet)));
            }

            [Test]
            public void MilitaryPowerRatioShouldReturnCorrectAmount()
            {
                var weapon = new Weapon("Name1", 5, 10);
                var weapon2 = new Weapon("Name2", 5, 20);
                var weapon3 = new Weapon("Name3", 5, 30);

                planet.AddWeapon(weapon);
                planet.AddWeapon(weapon2);
                planet.AddWeapon(weapon3);

                Assert.That(planet.MilitaryPowerRatio, Is.EqualTo(60));
            }

            [Test]
            public void MilitaryPowerRatioShouldReturnZeroWhenNoWeapons()
            {
                Assert.That(planet.MilitaryPowerRatio, Is.EqualTo(0));
            }

            [Test]
            public void WeaponNuclearIsFalse()
            {
                var weapon = new Weapon("Name", 5, 8);

                planet.AddWeapon(weapon);
                planet.UpgradeWeapon("Name");
                Assert.IsFalse(weapon.IsNuclear);
            }

            [Test]
            public void WeaponNuclearIsTrue()
            {
                var weapon = new Weapon("Name", 5, 9);

                planet.AddWeapon(weapon);
                planet.UpgradeWeapon("Name");

                Assert.IsTrue(weapon.IsNuclear);
            }
        }
    }
}
