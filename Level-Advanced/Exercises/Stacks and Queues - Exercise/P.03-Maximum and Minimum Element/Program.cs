using System;
using System.Collections.Generic;
using System.Linq;

namespace P._03_Maximum_and_Minimum_Element
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();

            int iterations = int.Parse(Console.ReadLine());

            for (int i = 1; i <= iterations; i++)
            {
                int[] arr = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                int cmd = arr[0];

                if (cmd == 1)
                {
                    int numberToPush = arr[1];
                    stack.Push(numberToPush);
                }
                else if (cmd == 2)
                {
                    if (stack.Count > 0)
                    {
                        stack.Pop();
                    }
                }
                else if (cmd == 3)
                {
                    if (stack.Count == 0)
                    {
                        continue;
                    }
                    Console.WriteLine(stack.Max());
                }
                else if (cmd == 4)
                {
                    if (stack.Count == 0)
                    {
                        continue;
                    }
                    Console.WriteLine(stack.Min());
                }
            }

            if (stack.Count > 0)
            {
                Console.WriteLine(string.Join(", ", stack));
            }
        }
    }
}
