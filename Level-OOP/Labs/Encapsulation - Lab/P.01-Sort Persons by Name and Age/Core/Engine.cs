using PracticeForJudge.Core.Interfaces;
using PracticeForJudge.IO;
using PracticeForJudge.IO.Interfaces;
using PracticeForJudge.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PracticeForJudge.Core
{
    public class Engine : IEngine
    {
        private readonly IWriter writer;
        private readonly IReader reader;
        private readonly IController controller;

        public Engine()
        {
            this.writer = new Writer();
            this.reader = new Reader();
            this.controller = new Controller();
        }

        public void Run()
        {
            //code which i used to write in Main

            var lines = int.Parse(reader.ReadLine());
            var people = new List<Person>();

            for (int i = 0; i < lines; i++)
            {
                var tokens = reader.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                var firstName = tokens[0];
                var secondName = tokens[1];
                var age = int.Parse(tokens[2]);

                var person = controller.CreatePerson(firstName, secondName, age);
                people.Add(person);
            }

            people.OrderBy(x => x.FirstName)
                .ThenBy(x => x.Age)
                .ToList()
                .ForEach(x => writer.WriteLine(x.ToString()));
        }
    }
}
