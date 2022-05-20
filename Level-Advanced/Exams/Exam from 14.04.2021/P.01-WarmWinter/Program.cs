using System;
using System.Linq;
using System.Collections.Generic;

namespace P._01_WarmWinter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] hats = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] scarfs = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> hatsStack = new Stack<int>(hats);
            Queue<int> scarfsQueue = new Queue<int>(scarfs);
            List<int> sets = new List<int>();

            while (hatsStack.Any() && scarfsQueue.Any())
            {
                int currentHat = hatsStack.Peek();
                int currentScarf = scarfsQueue.Peek();

                if (currentHat > currentScarf)
                {
                    int setPrice = currentHat + currentScarf;
                    sets.Add(setPrice);

                    hatsStack.Pop();
                    scarfsQueue.Dequeue();
                }
                else if (currentScarf > currentHat)
                {
                    hatsStack.Pop();
                }
                else if (currentHat == currentScarf)
                {
                    scarfsQueue.Dequeue();

                    var hat = hatsStack.Pop() + 1;
                    hatsStack.Push(hat);
                }
            }

            Console.WriteLine($"The most expensive set is: {sets.Max()}");
            Console.WriteLine(string.Join(" ", sets));
        }
    }
}
