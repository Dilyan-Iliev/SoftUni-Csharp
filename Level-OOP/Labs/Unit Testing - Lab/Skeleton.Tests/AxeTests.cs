using System;
using NUnit.Framework;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        private Axe axe;
        private Dummy dummy;

        [SetUp]
        public void InitializeTest()
        {
            this.axe = new Axe(5, 2);
            this.dummy = new Dummy(10, 10);
        }

        [Test]
        public void AxeShouldLoseDurabilityAfterAttack()
        {
            //•	Test if weapon loses durability after each attack

            axe.Attack(dummy);

            Assert.AreEqual(1, axe.DurabilityPoints, "Durability Points do not change.");
        }

        [Test]
        public void AxeShouldGetBrokenWhenNoDurabilityLeft()
        {
            //•	Test attacking with a broken weapon

            axe.Attack(dummy);
            axe.Attack(dummy);

            Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy),\
                "Axe Durability Points are more than 0");
        }
    }
}