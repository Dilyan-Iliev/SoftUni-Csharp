using System;
using System.Linq;
using System.Collections.Generic;

namespace Orders
{
    internal class Program
    {
        //static void Main(string[] args)
        //{
        //    var dictionary = new Dictionary<string, List<decimal>>();
        //    string input;

        //    while ((input = Console.ReadLine()) != "buy")
        //    {
        //        string[] inputArgs = input.Split();
        //        string key = inputArgs[0];
        //        decimal price = decimal.Parse(inputArgs[1]);
        //        int quantity = int.Parse(inputArgs[2]);


        //        if (!dictionary.ContainsKey(key))
        //        {
        //            dictionary[key] = new List<decimal>();
        //            dictionary[key].Add(price);
        //            dictionary[key].Add(quantity);
        //        }
        //        else // if dictionary.ContainsKey(key))
        //        {
        //            dictionary[key][0] = price; //на нулева позиция в списъка
        //            dictionary[key][1] += quantity; //на 1ва позиция в списъка
        //        }

        //    }
        //    foreach (var product in dictionary)
        //    {
        //        Console.WriteLine($"{product.Key} -> {(product.Value[0] * product.Value[1]):f2}");
        //    }
        //}
        // OR below
        static void Main(string[] args)
        {
            var dictionary = new Dictionary<string, Product>();

            string input;
            while ((input = Console.ReadLine()) != "buy")
            {
                string[] inputArgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string productName = inputArgs[0];
                decimal productPrice = decimal.Parse(inputArgs[1]);
                int productQuantity = int.Parse(inputArgs[2]);

                var newProduct = new Product(productName, productPrice, productQuantity);

                if (!dictionary.ContainsKey(productName))
                {//If the product doesn’t exist yet, add it with its starting quantity.

                    dictionary.Add(productName, newProduct);
                }
                else if (dictionary.ContainsKey(productName))
                //If you receive a product, which already exists, increase its quantity by the input quantity and if its price is different,replace the price as well.
                {
                    var product = dictionary[productName]; //вземам стойностите на key productName
                    product.UpdatedProduct(product, productPrice, productQuantity);

                    dictionary[productName] = product;
                }
            }

            foreach (var product in dictionary)
            {
                Console.WriteLine($"{product.Key} -> {product.Value.GetTotalSum():F2}");
            }
        }
    }

    class Product
    {
        public Product(string name, decimal price, int quantity)
        {
            this.ProductName = name;
            this.ProductPrice = price;
            this.ProductQuantity = quantity;
        }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductQuantity { get; set; }

        public decimal GetTotalSum()
        {
            return this.ProductPrice * this.ProductQuantity;
        }

        public Product UpdatedProduct(Product p, decimal price, int newQuantity)
        {
            p.ProductQuantity += newQuantity;
            p.ProductPrice = price;

            return p;
        }
    }
}
