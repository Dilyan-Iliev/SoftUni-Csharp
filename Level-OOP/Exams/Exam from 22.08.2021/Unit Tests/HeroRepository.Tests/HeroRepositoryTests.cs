using System;
using System.Linq;
using NUnit.Framework;

public class HeroRepositoryTests
{
    private HeroRepository heroRepository;

    [SetUp]
    public void TestInitializer()
    {
        //Arrange
        heroRepository = new HeroRepository();
    }

    [Test]
    public void ConstructorShouldInitializeCollection()
    {
        //Act and Assert
        Assert.IsNotNull(heroRepository.Heroes);
    }

    [Test]
    public void HeroesCollectionShouldSetValidDataOfZero()
    {
        //Act and Assert
        Assert.AreEqual(0, heroRepository.Heroes.Count);
    }

    [Test]
    public void CreateMethodShouldThrowExceptionWhenHeroToAddIsNull()
    {
        //Arrange
        Hero hero = null;

        //Act and Assert
        Assert.Throws<ArgumentNullException>(
            () => heroRepository.Create(hero), "Hero is null");
    }

    [Test]
    public void CreateMethodShouldThrowExceptionWhenHeroNameIsDuplicated()
    {
        //Arrange
        Hero hero = new Hero("Peter", 5);

        heroRepository.Create(hero);

        Hero duplicatedNameHero = new Hero("Peter", 6);

        //Act and Assert
        Assert.Throws<InvalidOperationException>(
            () => heroRepository.Create(duplicatedNameHero),
            $"Hero with name {duplicatedNameHero.Name} already exists");
    }

    [Test]
    public void CreateMethodShouldIncreaseCollection()
    {
        //Arrange
        Hero hero = new Hero("Peter", 4);

        //Act
        heroRepository.Create(hero);

        //Assert
        Assert.AreEqual(1, heroRepository.Heroes.Count);
    }

    [Test]
    public void CreateMethodShouldReturnCorrectMessage()
    {
        //Arrange
        Hero hero = new Hero("Peter", 5);

        //Act
        heroRepository.Create(hero);

        //Assert
        string expectedMessage = "Successfully added hero Peter with level 5";
        string actualMessage = $"Successfully added hero {hero.Name} with level {hero.Level}";

        Assert.AreEqual(expectedMessage, actualMessage);
    }

    [Test]
    public void RemoveMethodShouldThrowExceptionWhenNameIsNull()
    {
        //Arrange
        string heroName = null;
        int heroLevel = 5;
        Hero hero = new Hero(heroName, heroLevel);

        //Act
        heroRepository.Create(hero);

        //Assert
        Assert.Throws<ArgumentNullException>(
            () => heroRepository.Remove(heroName));
    }

    [Test]
    public void RemoveMethodShouldThrowExceptionWhenNameIsWhiteSpaace()
    {
        //Arrange
        string heroName = " ";
        int heroLevel = 5;
        Hero hero = new Hero(heroName, heroLevel);

        //Act
        heroRepository.Create(hero);

        //Assert
        Assert.Throws<ArgumentNullException>(
            () => heroRepository.Remove(heroName));
    }

    [Test]
    public void RemoveMethodShouldThrowExceptionWhenNameIsEmptyString()
    {
        //Arrange
        string heroName = string.Empty;
        int heroLevel = 5;
        Hero hero = new Hero(heroName, heroLevel);

        //Act
        heroRepository.Create(hero);

        //Assert
        Assert.Throws<ArgumentNullException>(
            () => heroRepository.Remove(heroName));
    }

    [Test]
    public void RemoveMethodShouldDecreaseCollectionCount()
    {
        //Arrange
        Hero firstHero = new Hero("John", 5);
        Hero secondHero = new Hero("Peter", 4);
        Hero thirdHero = new Hero("Michael", 3);

        //Act
        heroRepository.Create(firstHero);
        heroRepository.Create(secondHero);
        heroRepository.Create(thirdHero);

        heroRepository.Remove("John");

        //Assert
        Assert.AreEqual(2, heroRepository.Heroes.Count);
    }

    [Test]
    public void RemoveMethodShouldReturnTrueWhenSearchedHeroIsFound()
    {
        //Arrange
        Hero hero = new Hero("John", 5);

        //Act
        heroRepository.Create(hero);

        bool result = heroRepository.Remove("John");

        //Assert
        Assert.True(result);
    }

    [Test]
    public void RemoveMethodShouldReturnFalseWhenSearchedHeroIsNotFound()
    {
        //Act
        bool result = heroRepository.Remove("Peter");

        //Assert
        Assert.False(result);
    }

    [Test]
    public void GetHeroWithHighestLevelShouldWorkCorrectly()
    {
        //Arrange
        Hero firstHero = new Hero("John", 3);
        Hero secondHero = new Hero("Peter", 5);
        Hero thirdHero = new Hero("Michael", 9);

        //Act
        heroRepository.Create(firstHero);
        heroRepository.Create(secondHero);
        heroRepository.Create(thirdHero);

        //Assert
        Assert.AreEqual(thirdHero,
            heroRepository.GetHeroWithHighestLevel());
    }

    [Test]
    public void GetHeroShouldReturnTheSearchedHero()
    {
        //Arrange
        Hero firstHero = new Hero("John", 4);
        Hero secondHero = new Hero("Peter", 7);
        Hero thirdHero = new Hero("Bob", 9);

        //Act
        heroRepository.Create(firstHero);
        heroRepository.Create(secondHero);
        heroRepository.Create(thirdHero);

        //Assert
        var correctHero = heroRepository.GetHero("Bob");
        Assert.AreEqual(thirdHero, correctHero);
    }
}