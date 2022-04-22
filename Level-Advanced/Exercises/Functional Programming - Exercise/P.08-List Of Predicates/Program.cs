using System;
using System.Linq;
using System.Collections.Generic;

namespace P._08_List_Of_Predicates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int startOfRange = 1;
            int endOfRange = int.Parse(Console.ReadLine());

            var dividers = Console.ReadLine()
                .Split()
                .Select(int.Parse);

            var filteredNumbers = FilterCollection(dividers.ToList(),startOfRange, endOfRange);
            Console.WriteLine(string.Join(" ", filteredNumbers));
        }

        static IEnumerable<int> FilterCollection(IEnumerable<int> dividers, int startOfRange, int endOfRange)
        {
            List<int> result = new List<int>();
            for (int i = startOfRange; i <= endOfRange; i++)
            {

                bool isDivisible = true;
                foreach (var divider in dividers)
                {
                    Func<int, bool> divideFilter = x => i % x != 0; //where x is each divider
                    //this makes it a bool method -> example static bool Checker(int number) - return true/false
                    if (divideFilter(divider))
                    {
                        isDivisible = false;
                        break;
                    }
                }

                if (isDivisible)
                {
                    result.Add(i);
                }
            }

            return result;
        }
    }
}
