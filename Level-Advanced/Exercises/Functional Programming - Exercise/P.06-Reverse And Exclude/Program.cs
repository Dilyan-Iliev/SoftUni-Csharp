using System;
using System.Linq;
using System.Collections.Generic;

namespace P._06_Reverse_And_Exclude
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                 .Split()
                 .Select(int.Parse)
                 .Reverse();
               

            int numberToDivideOn = int.Parse(Console.ReadLine());

            IEnumerable<int> result = RemoveElements(numbers.ToList(), x=> x % numberToDivideOn != 0);
            //numbers.RemoveAll(x => x % numberToDivideOn == 0);

            Console.WriteLine(string.Join(" ", result));
        }

        static IEnumerable<int> RemoveElements(List<int> list, Func<int, bool> filter)
        {
            List<int> result = new List<int>();
            foreach (var number in list)
            {
                if (filter(number))
                {
                    result.Add(number);
                }
            }
            return result;
        }
    }
}
