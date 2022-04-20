using System;
using System.Linq;

namespace P._04_Add_VAT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<string, double> parsingFunction = x => double.Parse(x);
            Func<double, double> addPercantageFunction = x => x + x * 0.2;

            var numbers = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(parsingFunction)
                .Select(addPercantageFunction);
                //.ToArray();

            foreach (var number in numbers)
            {
                Console.WriteLine($"{number:F2}");
            }
        }
    }
}
