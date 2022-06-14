using P._05_Birthday_Celebrations.Classes;
using P._05_Birthday_Celebrations.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace P._05_Birthday_Celebrations
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var dictionary = new Dictionary<string, IInformational>();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] inputArgs = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string objType = inputArgs[0];
                string name = inputArgs[1];

                IInformational obj = null;

                if (objType == "Citizen")
                {
                    int age = int.Parse(inputArgs[2]);
                    string id = inputArgs[3];
                    string birthdate = inputArgs[4];

                    obj = new Citizen(name, age, id, birthdate);
                }
                else if (objType == "Pet")
                {
                    string birthdate = inputArgs[2];

                    obj = new Pet(name, birthdate);
                }
                else if (objType == "Robot")
                {
                    continue;
                }

                if (!dictionary.ContainsKey(name))
                {
                    dictionary[name] = obj;
                }
            }

            string specificYear = Console.ReadLine();

            var filtered = dictionary
                .Where(x => x.Value.Birthdate.EndsWith(specificYear));

            foreach (var item in filtered)
            {
                Console.WriteLine(item.Value.Birthdate);
            }
        }
    }
}
