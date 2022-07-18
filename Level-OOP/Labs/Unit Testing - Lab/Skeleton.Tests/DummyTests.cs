using System;
using NUnit.Framework;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        private const int Health = 2;
        private const int Experience = 5;
        private const int AttackPoints = 2;

        private Dummy dummy;

        [SetUp]
        public void InitializeTest()
        {
            this.dummy = new Dummy(Health, Experience);
        }

        [Test]
        public void DummyShouldLoseHealtIfAttaked()
        {
            //•	Dummy loses health if attacked

            dummy.TakeAttack(AttackPoints);

            //Assert.AreEqual(0, dummy.Health);

            //or

            Assert.IsTrue(dummy.Health < Health);
        }

        [Test]
        public void DummyShouldThrowExceptionIfAttacked()
        {
            //•	Dead Dummy throws an exception if attacked

            dummy.TakeAttack(AttackPoints);

            Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(AttackPoints));
        }

        [Test]
        public void DeadDummyShouldGiveXP()
        {
            //•	Dead Dummy can give XP

            dummy.TakeAttack(AttackPoints);

            //Assert.AreEqual(dummy.GiveExperience(), Experience);

            //or 

            Assert.IsTrue(dummy.IsDead());
        }

        [Test]
        public void AliveDummyShouldntGiveXP()
        {
            //•	Alive Dummy can't give XP

            dummy.TakeAttack(AttackPoints);
            
            Assert.IsFalse(dummy.IsDead());
        }
    }
}