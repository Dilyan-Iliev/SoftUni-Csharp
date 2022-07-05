using System.Collections.Generic;
using System.Linq;

namespace _7.Models
{
    public class Person
    {
        string name;
        decimal money;
        private ICollection<Product> products;

        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
            products = new List<Product>();
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
        public decimal Money
        {
            get => money;
            private set
            {
                if (value < 0)
                {
                    throw new System.ArgumentException("Money cannot be negative");
                }

                money = value;
            }
        }
        public IReadOnlyCollection<Product> Products
            => products.ToList().AsReadOnly();

        public string AddProduct(Product product)
        {
            if (Money - product.Cost < 0)
            {
                return $"{Name} can't afford {product.Name}";
            }

            products.Add(product);
            Money -= product.Cost;
            return $"{Name} bought {product.Name}";
        }

        public override string ToString()
        {
            if (!products.Any())
            {
                return $"{Name} - Nothing bought";
            }

            return $"{Name} - {string.Join(", ", products.Select(x => x.Name))}";
        }
    }
}
