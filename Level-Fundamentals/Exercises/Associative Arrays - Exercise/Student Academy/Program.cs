using System;
using System.Linq;
using System.Collections.Generic;

namespace Student_Academy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int pairOfRows = int.Parse(Console.ReadLine());
            var dictionary = new Dictionary<string, List<double>>();

            for (int i = 1; i <= pairOfRows; i++)
            {
                string student = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (!dictionary.ContainsKey(student))
                {
                    dictionary[student] = new List<double>();
                    dictionary[student].Add(grade);
                }
                else
                {
                    dictionary[student].Add(grade);
                }
            }

            foreach (var student in dictionary
                .Where(x => x.Value.Average(x => x)>=4.50))
            {
                Console.WriteLine($"{student.Key} -> {(student.Value.Average(x => x)):F2}");
            }
        }
    }
}
