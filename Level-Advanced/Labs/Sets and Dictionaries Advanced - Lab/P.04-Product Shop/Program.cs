using System;
using System.Linq;
using System.Collections.Generic;

namespace P._04_Product_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, double>> productsInStores = new Dictionary<string, Dictionary<string, double>>();

            string input;
            while ((input = Console.ReadLine()) != "Revision")
            {
                string[] inputArgs = input
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                string storeName = inputArgs[0];
                string product = inputArgs[1];
                double productPrice = double.Parse(inputArgs[2]);

                if (!productsInStores.ContainsKey(storeName))
                {
                    productsInStores.Add(storeName, new Dictionary<string, double>());
                }
                if (!productsInStores[storeName].ContainsKey(product))
                {
                    productsInStores[storeName][product] = productPrice;
                }
                else
                {
                    productsInStores[storeName][product] = productPrice;
                }
            }

            foreach (var store in productsInStores.OrderBy(x => x.Key)) //or use SortedDictionary everywhere
            {
                Console.WriteLine($"{store.Key}->");

                foreach (var product in store.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}
