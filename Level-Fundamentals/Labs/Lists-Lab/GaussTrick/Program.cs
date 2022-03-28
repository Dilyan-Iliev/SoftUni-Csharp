using System;
using System.Linq;
using System.Collections.Generic;

namespace GaussTrick
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> values = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();


            int currentCount = values.Count;

            for (int i = 0; i < currentCount/2; i++)
            {
                values[i] += values[values.Count - 1];
                values.RemoveAt(values.Count - 1);
            }

            
            Console.WriteLine(String.Join(" ",values));
        }
    }
}
