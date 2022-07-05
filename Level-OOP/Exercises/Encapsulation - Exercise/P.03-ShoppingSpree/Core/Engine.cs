using _7.Core.Interfaces;
using _7.IO;
using _7.IO.Interfaces;
using _7.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _7.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IController controller;

        public Engine()
        {
            this.reader = new ConsoleReader();
            this.writer = new ConsoleWriter();
            this.controller = new Controller();
        }
        public void Run()
        {
            var people = new List<Person>();
            var products = new List<Product>();

            var peopleArray = reader.ReadLine()
                .Split(';', StringSplitOptions.RemoveEmptyEntries);

            var productsArray = reader.ReadLine()
                .Split(';', StringSplitOptions.RemoveEmptyEntries);

            try
            {
                for (int i = 0; i < peopleArray.Length; i++)
                {
                    var tokens = peopleArray[i].Split('=');

                    var name = tokens[0];
                    var money = decimal.Parse(tokens[1]);

                    Person person = controller.CreatePerson(name, money);
                    people.Add(person);
                }

                for (int i = 0; i < productsArray.Length; i++)
                {
                    var tokens = productsArray[i].Split('=');

                    var name = tokens[0];
                    var cost = decimal.Parse(tokens[1]);

                    Product product = controller.CreateProduct(name, cost);
                    products.Add(product);
                }

                string input;
                while ((input = reader.ReadLine()) != "END")
                {
                    var tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    var personName = tokens[0];
                    var productName = tokens[1];

                    Person person = people
                        .FirstOrDefault(x => x.Name == personName);

                    Product product = products
                        .FirstOrDefault(x => x.Name == productName);

                    var result = person.AddProduct(product);
                    writer.WriteLine(result);
                }

                foreach (var item in people)
                {
                    writer.WriteLine(item.ToString());
                }
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
    }
}
