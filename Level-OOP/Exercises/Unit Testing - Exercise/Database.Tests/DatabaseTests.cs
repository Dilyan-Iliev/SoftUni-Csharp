namespace Database.Tests
{
    using System;
    using System.Linq;
    using NUnit.Framework;

    [TestFixture]
    public class DatabaseTests
    {
        private const int DatabaseCapacity = 16;

        private Database database;

        [SetUp]
        public void InitializeTest()
        {
            database = new Database();
        }


        [Test]
        [TestCase(3)]   
        [TestCase(DatabaseCapacity)]
        [TestCase(5)]
        [TestCase(0)]
        public void AddMethodShouldAddElementsWhileCountIsLessThan16(int count)
        {
            //Arrange is done in the InitializeTest();

            //Act
            //database.Add(1);
            //database.Add(2);
            //database.Add(3);
            for (int i = 0; i < count; i++)
            {
                database.Add(i);
            }

            //Assert
            Assert.AreEqual(count, database.Count);
        }

        [Test]
        public void AddMethodShouldThrowExceptionIfAddMoreThan16Elements()
        {
            //Act
            for (int i = 0; i < DatabaseCapacity; i++)
            {
                database.Add(i);
            }

            //Assert
            Assert.Throws<InvalidOperationException>(() => database.Add(1));
            //if we add one more element - count will be more than 16
        }

        [Test]
        [TestCase(1, 4)] //start, count
        [TestCase(1, 15)]
        [TestCase(1, 16)]
        public void ConstructorShouldAddAllItemsWhileTheyAreLessThan16
            (int start, int count)
        {
            //Arrange
            int[] elements = Enumerable.Range(start, count).ToArray();
            //array with n elements -> from n - count more elements above 
            //which means for loop from n until <= count
            database = new Database(elements);


            Assert.AreEqual(count, database.Count);
        }

        [Test]
        [TestCase(1,17)]
        [TestCase(1, 23)]
        public void ConstructorShouldThrowExceptionIfAbove16Items
            (int start, int count)
        {
            int[] elements = Enumerable.Range(start, count).ToArray();


            Assert.Throws<InvalidOperationException>(() 
                => new Database(elements));
            //throw exception if create Database object with more than 16 elements
        }

        [Test]
        [TestCase(1,10)]
        [TestCase(1,5)]
        public void RemoveShouldRemoveElementsWhenTheyAreMoreThan0
            (int start, int count)
        {
            //Arrange
            int[] elements = Enumerable.Range(start, count).ToArray();
            database = new Database(elements);

            //Act
            database.Remove();

            //Assert
            Assert.AreEqual(count - 1, database.Count);
        }

        [Test]
        public void RemoveShouldThrowExceptionWhen0Elements()
        {
            int[] elements = Enumerable.Range(1, 1).ToArray();
            database = new Database(elements);
            database.Remove();
            Assert.Throws<InvalidOperationException>(() => database.Remove());

            //or only

            //Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        [TestCase(1, 3)]
        [TestCase(1, 10)]
        [TestCase(1, 1)]
        public void FetchShouldReturnAllElementsAsArray
            (int start, int count)
        {
            //Arrange
            int[] elements = Enumerable.Range(start, count).ToArray();
            database = new Database(elements);

            //Act
            int[] fetched = database.Fetch();

            //Assert
            Assert.AreEqual(fetched.Length, count);
        }
    }
}
