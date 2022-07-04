using _4.Core.Interfaces;
using _4.IO.Interfaces;
using PersonsInfo.IO;
using PersonsInfo.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IController controller;

        public Engine()
        {
            this.reader = new Reader();
            this.writer = new Writer();
            this.controller = new Controller();
        }
        public void Run()
        {
            var lines = int.Parse(reader.ReadLine());
            var people = new List<Person>();

            for (int i = 0; i < lines; i++)
            {
                var tokens = reader.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string firstName = tokens[0];
                string lastName = tokens[1];
                int age = int.Parse(tokens[2]);
                decimal salary = decimal.Parse(tokens[3]);
                try
                {
                    var person = controller.CreatePerson(firstName, lastName, age, salary);
                    people.Add(person);

                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            var percentageIncrease = decimal.Parse(reader.ReadLine());
            people.ForEach(x => x.IncreaseSalary(percentageIncrease));
            people.ForEach(x => writer.WriteLine(x.ToString()));
        }
    }
}
