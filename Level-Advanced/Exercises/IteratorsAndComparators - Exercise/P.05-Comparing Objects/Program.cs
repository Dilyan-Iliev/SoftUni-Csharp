using System;
using System.Collections.Generic;

namespace P._05_Comparing_Objects
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] inputArgs = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string name = inputArgs[0];
                int age = int.Parse(inputArgs[1]);
                string town = inputArgs[2];

                Person person = new Person(name, age, town);
                people.Add(person);
            }

            int nthPerson = int.Parse(Console.ReadLine()) - 1;

            int matchesCounter = 0;
            int nonMatchesCounter = 0;
            int totalPeople = people.Count;

            Person comparedPerson = people[nthPerson];
            foreach (var person in people)
            {
                if (person.CompareTo(comparedPerson) == 0)
                {
                    matchesCounter++;
                }
                else
                {
                    nonMatchesCounter++;
                }
            }
            if (matchesCounter > 1)
            {
                Console.WriteLine($"{matchesCounter} {nonMatchesCounter} {totalPeople}");
            }
            else
            {
                Console.WriteLine("No matches");
            }
        }
    }
}
