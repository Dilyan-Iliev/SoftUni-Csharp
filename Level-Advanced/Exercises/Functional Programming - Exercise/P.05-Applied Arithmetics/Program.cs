using System;
using System.Linq;
using System.Collections.Generic;

namespace P._05_Applied_Arithmetics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();


            string command = Console.ReadLine();
            Action<string> operations = x =>
            {//action which will aply when it is invoked (below in the while loop)
                switch (x)
                {
                    case "add": numbers = numbers.Select(x => x + 1).ToArray(); break;
                    case "multiply": numbers = numbers.Select(x => x * 2).ToArray(); break;
                    case "subtract": numbers = numbers.Select(x => x - 1).ToArray(); break;
                    case "print": Console.WriteLine(string.Join(" ", numbers)); break;
                }
            };

            while (command  != "end")
            {
                operations(command);

                command = Console.ReadLine();
            }
        }
    }
}
