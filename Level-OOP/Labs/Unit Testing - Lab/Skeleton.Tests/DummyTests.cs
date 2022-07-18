using System;
using NUnit.Framework;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        private Dummy dummy;

        [SetUp]
        public void InitializeTest()
        {
            this.dummy = new Dummy(5, 5);
        }

        [Test]
        public void DummyShouldLoseHealtIfAttaked()
        {
            //•	Dummy loses health if attacked

            dummy.TakeAttack(2);

            Assert.AreEqual(3, dummy.Health);
        }

        [Test]
        public void DummyShouldThrowExceptionIfAttacked()
        {
            //•	Dead Dummy throws an exception if attacked

            dummy.TakeAttack(5);

            Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(5));
        }

        [Test]
        public void DeadDummyShouldGiveXP()
        {
            //•	Dead Dummy can give XP

            dummy.TakeAttack(5);

            Assert.IsTrue(dummy.IsDead());
        }

        [Test]
        public void AliveDummyShouldntGiveXP()
        {
            //•	Alive Dummy can't give XP

            dummy.TakeAttack(3);
            
            Assert.IsFalse(dummy.IsDead());
        }
    }
}