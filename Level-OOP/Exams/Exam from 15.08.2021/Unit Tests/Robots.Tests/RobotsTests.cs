namespace Robots.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class RobotsTests
    {
        [Test]
        public void ConstructorShouldSetCapacity()
        {
            //Arrange
            var robots = new RobotManager(4);

            //Act & Assert
            Assert.AreEqual(4, robots.Capacity);
        }

        [Test]
        public void ConstructorShouldThrowAnExceptionForNegativeCapacity()
        {
            //Act & Assert
            Assert.Throws<ArgumentException>(() => new RobotManager(-3));
        }

        [Test]
        public void EmptyRobotManagerShouldHaveCountOfZero()
        {
            //Arrange
            var robots = new RobotManager(100);

            //Act & Assert
            Assert.AreEqual(0, robots.Count);
        }

        [Test]
        public void RobotManagerShouldHaveProperCount()
        {
            //Arrange
            var robots = new RobotManager(100);

            //Act
            robots.Add(new Robot("r1", 100));
            robots.Add(new Robot("r2", 100));
            robots.Add(new Robot("r3", 100));

            //Assert
            Assert.AreEqual(3, robots.Count);
        }

        [Test]
        public void AddShouldThrowAnExceptionForRobotsWithTheSameName()
        {
            //Arrange
            var robots = new RobotManager(100);

            //Act
            robots.Add(new Robot("r1", 100));

            //Assert
            Assert.Throws<InvalidOperationException>(
                () => robots.Add(new Robot("r1", 1000)));
        }

        [Test]
        public void AddShouldThrowAnExceptionWhenCapacityIsReached()
        {
            //Arrange
            var robots = new RobotManager(2);

            //Act
            robots.Add(new Robot("r1", 100));
            robots.Add(new Robot("r2", 100));

            //Assert
            Assert.Throws<InvalidOperationException>(
                () => robots.Add(new Robot("r3", 1000)));
        }

        [Test]
        public void RemoveShouldWorkProperly()
        {
            //Arrange
            var robots = new RobotManager(2);

            //Act
            robots.Add(new Robot("r1", 100));
            robots.Add(new Robot("r2", 100));
            robots.Remove("r2");

            //Assert
            Assert.AreEqual(1, robots.Count);
            robots.Remove("r1");
            Assert.AreEqual(0, robots.Count);
        }

        [Test]
        public void RemoveShouldThrowAnExceptionWhenRobotIsNotFound()
        {
            //Arrange
            var robots = new RobotManager(2);

            //Act
            robots.Add(new Robot("r1", 100));

            //Assert
            Assert.Throws<InvalidOperationException>(() => robots.Remove("r2"));
        }

        [Test]
        public void WorkShouldWorkCorrectly()
        {
            //Arrange
            var robots = new RobotManager(2);
            var robot = new Robot("r1", 100);

            //Act
            robots.Add(robot);
            robots.Work("r1", "...", 40);

            //Assert
            Assert.AreEqual(60, robot.Battery);
        }

        [Test]
        public void WorkShouldThrowAnExceptionWhenRobotIsNotFound()
        {
            //Arrange
            var robots = new RobotManager(2);

            //Act
            robots.Add(new Robot("r1", 100));

            //Assert
            Assert.Throws<InvalidOperationException>(
                () => robots.Work("r2", "...", 20));
        }

        [Test]
        public void WorkShouldThrowAnExceptionWhenRobotIsExhausted()
        {
            //Arrange
            var robots = new RobotManager(2);

            //Act
            robots.Add(new Robot("r1", 20));

            //Assert
            Assert.Throws<InvalidOperationException>(
                () => robots.Work("r1", "...", 30));
        }

        [Test]
        public void ChargeShouldWorkProperly()
        {
            //Arrange
            var robots = new RobotManager(2);
            var robot = new Robot("r1", 100);

            //Act
            robots.Add(robot);
            robots.Work("r1", "...", 60);
            robots.Charge("r1");

            //Assert
            Assert.AreEqual(100, robot.Battery);
        }

        [Test]
        public void ChargeShouldThrowAnExceptionWhenRobotIsNotFound()
        {
            //Arrange
            var robots = new RobotManager(2);

            //Act
            robots.Add(new Robot("r1", 100));

            //Assert
            Assert.Throws<InvalidOperationException>(
                () => robots.Charge("fsfsdfssfd"));
        }
    }
}
