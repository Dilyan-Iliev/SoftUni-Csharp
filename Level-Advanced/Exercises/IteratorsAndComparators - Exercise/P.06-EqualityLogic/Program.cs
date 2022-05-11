using System;
using System.Collections.Generic;

namespace P._06_EqualityLogic
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var hashset = new HashSet<Person>();
            var sortedSed = new SortedSet<Person>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string name = input[0];
                int age = int.Parse(input[1]);

                var person = new Person(name, age);

                hashset.Add(person); //прави GetHashCode  
                sortedSed.Add(person); //прави Equals     
            }

            Console.WriteLine(sortedSed.Count);
            Console.WriteLine(hashset.Count);
        }
    }
}
