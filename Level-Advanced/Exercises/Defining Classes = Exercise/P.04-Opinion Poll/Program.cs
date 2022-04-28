using System;
using System.Linq;
using System.Collections.Generic;

namespace P._04_Opinion_Poll
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var people = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                string[] personInfo = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string name = personInfo[0];
                int age = int.Parse(personInfo[1]);

                var guy = new Person(name, age);
                people.Add(guy);    
            }

            foreach (var person in people.OrderBy(x => x.Name))
            {
                if (person.Age > 30)
                {
                    Console.WriteLine(person.ToString());
                }
            }
        }
    }
}
