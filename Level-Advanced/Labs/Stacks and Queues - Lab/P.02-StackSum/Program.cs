using System;
using System.Collections.Generic;
using System.Linq;

namespace P._02_StackSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(x => int.Parse(x))
                .ToArray();

            Stack<int> stack = new Stack<int>(numbers);

            string command;
            while ((command = Console.ReadLine().ToLower()) != "end")
            {
                string[] cmdArgs = command.Split();

                string currentCmd = cmdArgs[0];

                if (currentCmd == "add")
                {
                    int firstNumberToAdd = int.Parse(cmdArgs[1]);
                    int secondNumberToAdd = int.Parse(cmdArgs[2]);

                    stack.Push(firstNumberToAdd);
                    stack.Push(secondNumberToAdd);
                }
                else if (currentCmd == "remove")
                {
                    int countOfNumbersToRemove = int.Parse(cmdArgs[1]);

                    if (stack.Count > countOfNumbersToRemove)
                    {
                        for (int i = 0; i < countOfNumbersToRemove; i++)
                        {
                            stack.Pop();
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            Console.WriteLine($"Sum: {stack.Sum()}");
        }
    }
}
