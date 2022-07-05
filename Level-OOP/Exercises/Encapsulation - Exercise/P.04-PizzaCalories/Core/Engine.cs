using _5.Core.Interfaces;
using _5.IO;
using _5.IO.Interfaces;
using _5.Models;
using System;

namespace _5.Core
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
            try
            {
                string[] pizzaInfo = reader.ReadLine()
                .Split();

                string pizzaName = pizzaInfo[1];

                string[] doughInfo = reader.ReadLine()
                    .Split();

                string doughFlourType = doughInfo[1];
                string bakingTechnique = doughInfo[2];
                double doughWeight = double.Parse(doughInfo[3]);

                Dough dough = controller.CreateDough(doughFlourType, bakingTechnique, doughWeight);
                Pizza pizza = controller.CreatePizza(pizzaName, dough);

                string toppingType = reader.ReadLine();

                while (toppingType != "END")
                {
                    string[] toppingInfo = toppingType
                        .Split();

                    string type = toppingInfo[1];
                    double toppingWeight = double.Parse(toppingInfo[2]);

                    Topping topping = controller.CreateTopping(type, toppingWeight);
                    pizza.AddTopping(topping);

                    toppingType = reader.ReadLine();
                }

                writer.WriteLine(pizza);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
    }
}
