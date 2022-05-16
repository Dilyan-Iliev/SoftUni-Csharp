using System;
using System.Collections.Generic;
using System.Linq;

namespace P._03_Maximum_and_Minimum_Element
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                int[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var command = input[0];

                if (command == 1)
                {
                    int elementToPush = input[1];
                    stack.Push(elementToPush);
                }
                else if (stack.Any())
                {
                    if (command == 2)
                    {
                        stack.Pop();
                    }
                    else if (command == 3)
                    {
                        Console.WriteLine(stack.Max());
                    }
                    else if (command == 4)
                    {
                        Console.WriteLine(stack.Min());
                    }
                }
            }
            Console.WriteLine(string.Join(", ", stack));
        }
    }
}
