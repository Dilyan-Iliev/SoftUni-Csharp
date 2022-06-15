using System;

namespace P._09_ExplicitInterfaces
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                var inputArgs = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string name = inputArgs[0];
                string country = inputArgs[1];
                int age = int.Parse(inputArgs[2]);

                Citizen citizen = new Citizen();

                var person = citizen as IPerson;
                person.Name = name;
                person.Age = age;
                Console.WriteLine(person.GetName(name));

                var resident = citizen as IResident;
                resident.Name = name;
                resident.Country = country;
                Console.WriteLine(resident.GetName(name));
            }
        }
    }
}
