using _7.Core.Interfaces;
using _7.IO;
using _7.IO.Interfaces;
using _7.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _7.Core
{
    public class Engine : IEngine
    {
        private readonly IWriter writer;
        private readonly IReader reader;
        private readonly IController controller;

        public Engine()
        {
            writer = new ConsoleWriter();
            reader = new ConsoleReader();
            controller = new Controller();
        }
        public void Run()
        {
            List<ICitizenType> citizens = new List<ICitizenType>();

            string input;
            while ((input = reader.ReadLine()) != "End")
            {
                ICitizenType citizen = null;

                string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length == 3)
                {
                    string name = parts[0];
                    int age = int.Parse(parts[1]);
                    string id = parts[2];

                    citizen = controller.CreateCitizien(name, age, id);
                }
                else if (parts.Length == 2)
                {
                    string model = parts[0];
                    string id = parts[1];

                    citizen = controller.CreateRobot(model, id);
                }

                citizens.Add(citizen);
            }

            string idToBeRemoved = reader.ReadLine();

            var removedCitizensByID = citizens
                .Where(x => x.Id.EndsWith(idToBeRemoved))
                .ToList();

            removedCitizensByID
                .ForEach(x => writer.WriteLine(x.Id));
        }
    }
}
