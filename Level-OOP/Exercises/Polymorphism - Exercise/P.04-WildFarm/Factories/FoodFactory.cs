namespace _8.Factories
{
    using _8.Exceptions;
    using _8.Models.Foods;
    using _8.Models.Interfaces;
    using _8.Factories.Interfaces;

    public class FoodFactory : IFoodFactory
    {
        public IFood Create(int quantity, string type)
        {
            IFood food = null;

            if (type == nameof(Fruit))
            {
                food = new Fruit(quantity);
            }
            else if (type == nameof(Vegetable))
            {
                food = new Vegetable(quantity);
            }
            else if (type == nameof(Meat))
            {
                food = new Meat(quantity);
            }
            else if (type == nameof(Seeds))
            {
                food = new Seeds(quantity);
            }
            else
            {
                throw new System.ArgumentException(ExceptionMessage.InvalidFoodCreated);
            }

            return food;
        }
    }
}
