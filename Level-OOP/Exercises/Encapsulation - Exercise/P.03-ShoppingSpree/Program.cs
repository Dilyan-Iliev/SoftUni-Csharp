using System;
using System.Collections.Generic;
using System.Linq;

namespace P._03_ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                Dictionary<string, Person> people = new Dictionary<string, Person>();
                Dictionary<string, Product> products = new Dictionary<string, Product>();

                string[] peopleArr = Console.ReadLine()
                    .Split(';', StringSplitOptions.RemoveEmptyEntries);

                string[] productsArr = Console.ReadLine()
                    .Split(';', StringSplitOptions.RemoveEmptyEntries);

                foreach (var person in peopleArr)
                {
                    string[] values = person.Split('=');
                    string name = values[0];
                    decimal money = decimal.Parse(values[1]);

                    Person currentPerson = new Person(name, money);
                    people.Add(currentPerson.Name, currentPerson);
                }

                foreach (var product in productsArr)
                {
                    string[] values = product.Split('=');
                    string name = values[0];
                    decimal cost = decimal.Parse(values[1]);

                    Product currentProduct = new Product(name, cost);
                    products.Add(currentProduct.Name, currentProduct);
                }

                string command;
                while ((command = Console.ReadLine()) != "END")
                {
                    string[] cmdArgs = command
                        .Split();

                    Person person = people[cmdArgs[0]];
                    Product product = products[cmdArgs[1]];

                    //string personName = cmdArgs[0];
                    //string productName = cmdArgs[1];

                    if (person.Money - product.Cost < 0)
                    {
                        Console.WriteLine($"{person.Name} can't afford {product.Name}");
                        continue;
                    }

                    person.AddProduct(product);
                    Console.WriteLine($"{person.Name} bought {product.Name}");
                }

                foreach (var item in people)
                {
                    if (item.Value.Products.Count == 0)
                    {
                        Console.WriteLine($"{item.Key} - Nothing bought");
                    }
                    else
                    {
                        var currentProducts = string.Join(", ", item.Value.Products.Select(x => x.Name));
                        Console.WriteLine($"{item.Key} - {currentProducts}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
        }
    }
}
