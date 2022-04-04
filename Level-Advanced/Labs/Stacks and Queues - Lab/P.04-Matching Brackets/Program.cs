using System;
using System.Collections.Generic;

namespace P._04_Matching_Brackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                char currentCh = input[i];

                if (currentCh == '(')
                {
                    stack.Push(i);
                }
                else if (currentCh == ')')
                {
                    int startIndex = stack.Pop();
                    string substring = input.Substring(startIndex, i - startIndex + 1);
                    Console.WriteLine(substring);
                }
            }
        }
    }
}
