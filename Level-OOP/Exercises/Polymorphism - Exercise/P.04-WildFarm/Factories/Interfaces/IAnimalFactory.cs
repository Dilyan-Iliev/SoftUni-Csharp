namespace _8.Factories.Interfaces
{
    using _8.Models.Interfaces;

    public interface IAnimalFactory
    {
        IAnimal Create(string type, string name, double weight,
            string fourthParam, string fifthParam = null);
    }
}
