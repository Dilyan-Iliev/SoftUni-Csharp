using System;
using NUnit.Framework;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        private const int AxeAtack = 1;
        private const int AxeDurability = 1;
        private const int DummyHealth = 10;
        private const int DummyExperience = 10;

        private Axe axe;
        private Dummy dummy;

        [SetUp]
        public void InitializeTest()
        {
            this.axe = new Axe(AxeAtack, AxeDurability);
            this.dummy = new Dummy(DummyHealth, DummyExperience);
        }

        [Test]
        public void AxeShouldLoseDurabilityAfterAttack()
        {
            //•	Test if weapon loses durability after each attack

            axe.Attack(dummy);

            Assert.AreEqual(0, axe.DurabilityPoints, "Durability Points do not change.");
        }

        [Test]
        public void AxeShouldGetBrokenWhenNoDurabilityLeft()
        {
            //•	Test attacking with a broken weapon

            axe.Attack(dummy);

            Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy),
                "Axe Durability Points are more than 0");

            //or 

            //Assert.That(() => axe.Attack(dummy), Throws.TypeOf<InvalidOperationException>().With.Message.EqualTo("Axe is broken."));
        }
    }
}