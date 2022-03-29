using System;
using System.Linq;
using System.Collections.Generic;

namespace Company_Users
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dictionary = new Dictionary<string, List<string>>();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] inputArgs = input.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                string company = inputArgs[0];
                string employeeID = inputArgs[1];

                if (!dictionary.ContainsKey(company))
                {
                    dictionary[company] = new List<string>(); //създавам списък с/у съответния ключ, за да мога да достъпвам този списък

                    if (!dictionary[company].Contains(employeeID))//проверявам дали елемент от списъка на съответния ключ отговаря на условието
                    {
                        dictionary[company].Add(employeeID); 
                    }
                    else if (dictionary[company].Contains(employeeID))
                    {
                        continue;
                    }
                }
                else if (dictionary.ContainsKey(company))
                {
                    if (!dictionary[company].Contains(employeeID))
                    {
                        dictionary[company].Add(employeeID);
                    }
                    else if (dictionary[company].Contains(employeeID))
                    {
                        continue;
                    }
                }
            }

            foreach (var company in dictionary)
            {
                Console.WriteLine($"{company.Key}");
                foreach (var id in company.Value)
                {
                    Console.WriteLine($"-- {id}");
                }
            }
        }
    }
}
