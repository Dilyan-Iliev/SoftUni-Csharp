using System;
using System.Collections.Generic;
using System.Linq;

namespace P._04_BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var dictionary = new Dictionary<string, IIdentifiable>();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] inputArgs = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                IIdentifiable obj = null;

                string name = inputArgs[0];

                if (inputArgs.Length == 2)
                {
                    obj = new Robot(name, inputArgs[1]);
                }
                else if (inputArgs.Length == 3)
                {
                    obj = new Citizen(name, int.Parse(inputArgs[1]), inputArgs[2]);
                }

                if (!dictionary.ContainsKey(name))
                {
                    dictionary[name] = obj;
                }
            }

            string fakeIDsNumber = Console.ReadLine();

            var filteredIDs = dictionary
                .Where(x => x.Value.ID.EndsWith(fakeIDsNumber));

            foreach (var item in filteredIDs)
            {
                Console.WriteLine(item.Value.ID);
            }
        }
    }
}
