using System;
using System.Linq;
using System.Collections.Generic;

namespace Remove_Negatives_and_Reverse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToList();

            numbers.RemoveAll(x => x < 0);
            numbers.Reverse();

            if (numbers.Count > 0)
            {
                Console.WriteLine(String.Join(" ",numbers));
            }
            else
            {
                Console.WriteLine("empty");
            }
        }
    }
}
