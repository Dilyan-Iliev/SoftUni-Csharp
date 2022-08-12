using NUnit.Framework;
using System;
using System.Linq;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        private BankVault vault;

        [SetUp]
        public void TestInitializer()
        {
            vault = new BankVault();
        }

        [Test]
        public void ConstrutorShouldInitializeCollection()
        {
            //Act & Assert
            Assert.IsNotNull(vault.VaultCells);
        }

        [Test]
        public void AllValuesShouldBeNull()
        {
            Assert.That
                (vault.VaultCells.Values.All(x => x == null));
        }

        [Test]
        public void AddItemMethodShouldThrowExceptionWhenTryAddItemToNonExistingKey()
        {
            //valid predifined keys are A1, A2,A3,A4,B1,B2,B3,B4,C1,C2,C3,C4

            //Act & Assert
            Assert.Throws<ArgumentException>(
                () => vault.AddItem("D1", null));
        }

        [Test]
        public void AddItemMethodShouldThrowExceptionWhenKeyIsAlreadyWithAddedValue()
        {
            //Act
            vault.AddItem("A3", new Item("Owner", "Id"));

            //Assert
            Assert.Throws<ArgumentException>(
                () => vault.AddItem("A3", new Item("Owner2", "Id2")));
        }

        [Test]
        public void AddItemMethodShouldThrowExceptionWhenTwoIdenticalValueIDs()
        {
            //Arrange
            Item item = new Item("Item2", "Id2");
            Item item2 = new Item("", "Id2");

            //Act
            vault.AddItem("A2", item);

            //Assert
            Assert.Throws<InvalidOperationException>(
                () => vault.AddItem("A3", item2));
        }

        [Test]
        public void AddItemShouldWorkCorrectlyByAddingValueToAPredifinedKey()
        {
            //Arrange
            Item item = new Item("Owner", "Id");

            //Act
            vault.AddItem("B2", item);

            //Assert
            //Assert.That(vault.VaultCells["B2"] == item);

            Assert.AreEqual("Id", vault.VaultCells["B2"].ItemId);
        }

        [Test]
        public void AddItemShouldWorkCorrectlyByReturningCorrectMessage()
        {
            //Arrange
            Item item = new Item("Owner", "Id");

            //Act & Assert
            string expectedMessage = "Item:Id saved successfully!";
            Assert.AreEqual(expectedMessage, vault.AddItem("B2", item));
        }

        [Test]
        public void RemoveItemMethodShouldThrowExceptionWhenNoKeyFound()
        {
            //Act & Assert
            Assert.Throws<ArgumentException>(
            () => vault.RemoveItem("F1", new Item("", "")));
        }

        [Test]
        public void RemoveItemMethodShouldThrowExceptionWhenKeyValueIsDifferentThanParamItem()
        {
            //Arrange
            Item item = new Item("Owner", "Id");
            Item item2 = new Item("Owner2", "Id2");

            //Act
            vault.AddItem("C1", item);

            //Assert
            Assert.Throws<ArgumentException>
                (() => vault.RemoveItem("C1", item2));
        }

        [Test]
        public void RemoveItemMethodShouldWorkCorrectlyBySettingKeyValueToNull()
        {
            //Arrange
            Item item = new Item("Owner", "Id");

            //Act
            vault.AddItem("B3", item);
            vault.RemoveItem("B3", item);

            //Assert
            Assert.That(vault.VaultCells["B3"] == null);
        }

        [Test]
        public void RemoveItemMethodShouldWorkCorrectlyByReturningCorrectMessage()
        {
            //Arrange
            Item item = new Item("Owner", "Id");

            //Act
            vault.AddItem("B3", item);

            //Assert
            var expected = "Remove item:Id successfully!";
            Assert.AreEqual(expected, vault.RemoveItem("B3", item));
        }
    }
}