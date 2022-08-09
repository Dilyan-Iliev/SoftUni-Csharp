namespace FightingArena.Tests
{
    using System;
    using System.Linq;
    using NUnit.Framework;

    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;

        [SetUp]
        public void ArenaInitializer()
        {
            arena = new Arena();    
        }

        [Test]
        public void ConstructorShouldInitializeAllValues()
        {
            //Assert
            Assert.IsNotNull(arena.Warriors);
        }

        [Test]
        public void EnrollMethodShouldAddWarriorIfDoesntExists()
        {
            //Arrange
            Warrior warrior = new Warrior("George", 50, 80);
            Warrior warrior2 = new Warrior("Peter", 150, 280);
            Warrior warrior3 = new Warrior("John", 350, 480);

            //Act
            arena.Enroll(warrior);
            arena.Enroll(warrior2);
            arena.Enroll(warrior3);

            //Assert
            Assert.AreEqual(3, arena.Count);

            bool warriorExists = arena.Warriors
                .Contains(warrior);
            bool warrior2Exists = arena.Warriors
                .Contains(warrior2);
            bool warrior3Exists = arena.Warriors
                .Contains(warrior3);

            Assert.True(warriorExists);
            Assert.True(warrior2Exists);
            Assert.True(warrior3Exists);
        }

        [Test]
        public void EnrollMethodShouldThrowExceptionForDuplicatedWarrior()
        {
            //Arrange
            Warrior warrior = new Warrior("John", 50, 100);
            
            //Act
            arena.Enroll(warrior);

            //Assert
            Assert.Throws<InvalidOperationException>
                (() => arena.Enroll(warrior));
        }

        [Test]
        public void FightMethodShouldThrowExceptionForInvalidWarriors()
        {
            Assert.Throws<InvalidOperationException>
                (() => arena.Fight("Gosho", "Kiro"),
                $"There is no figher with name enrolled for the fights!");
        }

        [Test]
        public void FightMethodShouldThrowExceptionForInvalidAttacker()
        {
            Warrior attacker = new Warrior("Kiro", 40, 70);

            arena.Enroll(attacker);

            Assert.Throws<InvalidOperationException>
                (() => arena.Fight("Gosho", "Kiro"),
                $"There is no fighter with name Gosho enrolled for the fights!");
        }

        [Test]
        public void FightMethodShouldThrowExceptionForInvalidDeffender()
        {
            Warrior deffender = new Warrior("Kiro", 40, 70);

            arena.Enroll(deffender); 

            Assert.Throws<InvalidOperationException>
                (() => arena.Fight("Kiro", "Gosho"),
                $"There is no figher with name Gosho enrolled for the fights!");
        }

        [Test]
        public void FightShouldReduceHP()
        {
            //Arrange
            Warrior attacker = new Warrior("John", 100, 50);
            Warrior deffender = new Warrior("Kiro", 40, 100);

            arena.Enroll(attacker);
            arena.Enroll(deffender);

            //Act
            arena.Fight("John", "Kiro");

            //Assert
            Warrior warriorAttacker = arena.Warriors.FirstOrDefault
                (x => x.Name == "John");

            Warrior warriorDeffender = arena.Warriors.FirstOrDefault
                (x => x.Name == "Kiro");

            Assert.AreEqual(10, warriorAttacker.HP);
            Assert.AreEqual(0, warriorDeffender.HP);

            Assert.Throws<InvalidOperationException>
                (() => arena.Fight("John", "Kiro"));
        }
    }
}
