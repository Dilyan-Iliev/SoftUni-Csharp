using System;
using System.Linq;
using System.Collections.Generic;

namespace Courses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dictionary = new Dictionary<string, List<string>>();

            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                string[] inputArgs = input.Split(" : ", StringSplitOptions.RemoveEmptyEntries);
                string course = inputArgs[0];
                string student = inputArgs[1];

                if (!dictionary.ContainsKey(course))
                {
                    dictionary[course] = new List<string>();
                    dictionary[course].Add(student);
                }
                else if (dictionary.ContainsKey(course))
                {
                    dictionary[course].Add(student);
                }
            }

            foreach (var course in dictionary)
            {
                Console.WriteLine($"{course.Key}: {course.Value.Count}");
                foreach (var student in course.Value)
                {
                    Console.WriteLine($"-- {student}");
                }
            }
        }
    }
}
