namespace _7.Models
{
    public class Product
    {
        private string name;
        private decimal cost;

        public Product(string name, decimal cost)
        {
            Name = name;
            Cost = cost;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new System.ArgumentException("Name cannot be empty");
                }

                name = value;
            }
        }
        public decimal Cost
        {
            get => cost;
            private set
            {
                if (value < 0)
                {
                    throw new System.ArgumentException("Money cannot be negative");
                }

                cost = value;
            }
        }
    }
}
