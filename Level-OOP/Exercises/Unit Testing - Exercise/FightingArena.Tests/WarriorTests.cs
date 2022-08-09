namespace FightingArena.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class WarriorTests
    {
        [Test]
        [TestCase("George", 50, 70)]
        [TestCase("Peter", 1, 0)]
        public void ConstructorShouldSetEverythingIfDataIsValid
            (string name, int damage, int hp)
        {
            //Arrange
            Warrior warrior = new Warrior(name, damage, hp);

            //Assert
            Assert.AreEqual(name, warrior.Name);
            Assert.AreEqual(damage, warrior.Damage);
            Assert.AreEqual(hp, warrior.HP);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void ConstructorShoudThrowArgumentExceptionForInvalidName
            (string name)
        {
            Assert.Throws<ArgumentException>
                (() => new Warrior(name, 40, 50));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void ConstructorShoudThrowArgumentExceptionForInvalidDamage
            (int dmg)
        {
            Assert.Throws<ArgumentException>
                (() => new Warrior("George", dmg, 50));
        }

        [Test]
        [TestCase(-1)]
        public void ConstructorShoudThrowArgumentExceptionForInvalidHP
            (int hp)
        {
            Assert.Throws<ArgumentException>
                (() => new Warrior("George", 60, hp));
        }

        [Test]
        [TestCase("George", 30, 50)]
        public void AttackMethodShouldThrowExceptionWhenHPIsBelowOrEqualTo30Deffender
            (string enemyName, int enemyHp, int enemyDamage)
        {
            Warrior myWarrior = new Warrior("Stoyan", 50, 60);
            Warrior enemyWarrior = new Warrior(enemyName, enemyDamage, enemyHp);

            Assert.Throws<InvalidOperationException>
                (() => myWarrior.Attack(enemyWarrior));
        }

        [Test]
        [TestCase("Peter", 30, 50)]
        public void AttackMethodShouldThrowExceptionWhenHPIsBelowOrEqualTo30Attacker
            (string name, int hp, int damage)
        {
            Warrior myWarrior = new Warrior(name, damage, hp);
            Warrior enemyWarrior = new Warrior("Kiro", 90, 90);

            Assert.Throws<InvalidOperationException>
                (() => myWarrior.Attack(enemyWarrior));
        }

        [Test]
        [TestCase("Peter", 10, 50)]
        public void AttackMethodShouldThrowExceptionWhenHPIsBelowOrEqualTo30AttackerVol2
            (string name, int hp, int damage)
        {
            Warrior myWarrior = new Warrior(name, damage, hp);
            Warrior enemyWarrior = new Warrior("Kiro", 90, 90);

            Assert.Throws<InvalidOperationException>
                (() => myWarrior.Attack(enemyWarrior));
        }

        [Test]
        [TestCase("George", 20, 50)]
        public void AttackMethodShouldThrowExceptionWhenHPIsBelowOrEqualTo30DeffenderVol2
            (string enemyName, int enemyHp, int enemyDamage)
        {
            Warrior myWarrior = new Warrior("Stoyan", 50, 60);
            Warrior enemyWarrior = new Warrior(enemyName, enemyDamage, enemyHp);

            Assert.Throws<InvalidOperationException>
                (() => myWarrior.Attack(enemyWarrior));
        }

        [Test]
        [TestCase("Peter", 50, 50, "George", 40, 90)]
        public void AttackMethodShouldThrowExceptionWhenOurHPisBelowEnemyDamage
            (string name, int hp, int damage,
            string enemyName, int enemyHp, int enemyDamage)
        {
            Warrior myWarrior = new Warrior(name, damage, hp);
            Warrior enemyWarrior = new Warrior(enemyName, enemyDamage, enemyHp);

            Assert.Throws<InvalidOperationException>
                (() => myWarrior.Attack(enemyWarrior));
        }

        [Test]
        [TestCase("George", 50, 100, 50,
                  "Peter", 50, 100, 50)]
        [TestCase("George", 100, 100, 50,
                  "Peter", 50, 100, 0)]
        [TestCase("George", 120, 100, 50,
                  "Peter", 50, 100, 0)]
        [TestCase("George", 100, 100, 0,
                  "Peter", 100, 100, 0)]
        public void AttackMethodShouldReduceHPForWarriorAndEnemyWarrior
            (string name, int damage, int hp, int resultHp,
            string enemyName, int enemyDamage, int enemyHp, int resultEnemyHp)
        {
            //Arrange
            Warrior myWarrior = new Warrior(name, damage, hp);
            Warrior enemyWarrior = new Warrior(enemyName, enemyDamage, enemyHp);

            //Act
            myWarrior.Attack(enemyWarrior);

            //Assert
            Assert.AreEqual(resultHp, myWarrior.HP);
            Assert.AreEqual(resultEnemyHp, enemyWarrior.HP);
        }


    }
}