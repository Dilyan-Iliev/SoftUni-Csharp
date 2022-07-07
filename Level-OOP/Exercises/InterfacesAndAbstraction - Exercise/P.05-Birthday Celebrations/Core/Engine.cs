using _7.Core.Interfaces;
using _7.IO;
using _7.IO.Interfaces;
using _7.Models;
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
            List<IBirthdate> birthdateCollection = new List<IBirthdate>();

            string input;
            while ((input = reader.ReadLine()) != "End")
            {
                IBirthdate obj = null;

                string[] tokens = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string type = tokens[0];

                switch (type)
                {
                    case "Pet":
                        string petName = tokens[1];
                        string petBirthdate = tokens[2];

                        obj = controller.CreatePet(petName, petBirthdate);

                        birthdateCollection.Add(obj);
                        break;

                    case "Citizen":
                        string citizenName = tokens[1];
                        int citizenAge = int.Parse(tokens[2]);
                        string citizenId = tokens[3];
                        string citizenBirthdate = tokens[4];

                        obj = controller.CreateCitizien(citizenName, citizenAge, citizenId, citizenBirthdate);

                        birthdateCollection.Add(obj);
                        break;

                    default:
                        continue;
                }
            }

            string birthdateYear = reader.ReadLine();

            var selectedObjs = birthdateCollection
                .Where(x => x.Birthdate.EndsWith(birthdateYear))
                .ToList();

            selectedObjs.ForEach(x => writer.WriteLine(x.Birthdate));
        }
    }
}
