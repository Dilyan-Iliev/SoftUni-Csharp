namespace _8.Factories
{
    using _8.Exceptions;
    using _8.Models.Interfaces;
    using _8.Factories.Interfaces;
    using _8.Models.Animals.Birds;
    using _8.Models.Animals.Mammals;

    public class AnimalFactory : IAnimalFactory
    {
        public IAnimal Create(string type, string name, double weight,
            string thirdParam, string fourthParam = null)
        {
            IAnimal animal = null;

            if (type == nameof(Owl))
            {
                animal = new Owl(name, weight, double.Parse(thirdParam));
            }
            else if (type == nameof(Hen))
            {
                animal = new Hen(name, weight, double.Parse(thirdParam));
            }
            else if (type == nameof(Mouse))
            {
                animal = new Mouse(name, weight, thirdParam);
            }
            else if (type == nameof(Dog))
            {
                animal = new Dog(name, weight, thirdParam);
            }
            else if (type == nameof(Cat))
            {
                animal = new Cat(name, weight, thirdParam, fourthParam);
            }
            else if (type == nameof(Tiger))
            {
                animal = new Tiger(name, weight, thirdParam, fourthParam);
            }
            else
            {
                throw new System.ArgumentException(ExceptionMessage.InvalidAnimalType);
            }

            return animal;
        }
    }
}
