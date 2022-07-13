namespace _8.Models.Foods
{
    using _8.Models.Interfaces;

    public abstract class Food : IFood
    {
        protected Food(int quantity)
        {
            Quantity = quantity;
        }

        public int Quantity { get; private set; } //protected set ? 

    }
}
