using System;
using System.Collections.Generic;
using System.Linq;

namespace P._01_Sort_Persons_by_Name_and_Age
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var people = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string firstName = input[0];
                string lastName = input[1];
                int age = int.Parse(input[2]);

                Person person = new Person(firstName, lastName, age);
                people.Add(person);
            }

            foreach (var person in people.OrderBy(x => x.FirstName)
                .ThenBy(x => x.Age))
            {
                Console.WriteLine(person.ToString());
            }
        }
    }
}
