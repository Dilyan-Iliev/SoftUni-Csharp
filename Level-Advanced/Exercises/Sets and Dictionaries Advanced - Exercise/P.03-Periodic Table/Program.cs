using System;
using System.Linq;
using System.Collections.Generic;

namespace P._03_Periodic_Table
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            SortedSet<string> chemicalsCompounds = new SortedSet<string>();

            for (int i = 0; i < n; i++)
            {
                string[] chemicals = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                for (int k = 0; k < chemicals.Length; k++)
                {
                    chemicalsCompounds.Add(chemicals[k]);
                }
            }
            Console.WriteLine(string.Join(' ', chemicalsCompounds));
        }
    }
}
