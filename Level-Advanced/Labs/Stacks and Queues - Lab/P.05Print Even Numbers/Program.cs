using System;
using System.Linq;
using System.Collections.Generic;

namespace Print_Even_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int[] numbers = Console.ReadLine()
            //    .Split(' ')
            //    .Select(int.Parse)
            //    .Where(x => x % 2 == 0)
            //    .ToArray();

            //Queue<int> queue = new Queue<int>(numbers);
            //Console.WriteLine(string.Join(", ", queue));



            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Queue<int> queue = new Queue<int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 == 0)
                {
                    queue.Enqueue(numbers[i]);
                }
            }
            Console.WriteLine(string.Join(", ", queue));
        }
    }
}
