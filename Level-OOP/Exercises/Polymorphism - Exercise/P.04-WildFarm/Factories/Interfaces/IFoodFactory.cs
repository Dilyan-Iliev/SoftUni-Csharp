namespace _8.Factories.Interfaces
{
    using _8.Models.Interfaces;

    public interface IFoodFactory
    {
        IFood Create(int quantity, string type);
    }
}
