using System;
using System.Collections.Generic;

namespace P._08_Balanced_Parenthesis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<char> stack = new Stack<char>();
            bool isValid = true;

            foreach(var symbol in input)
            {
                if (symbol == '(' || symbol == '[' || symbol == '{')
                {
                    stack.Push(symbol);
                }
                else
                {
                    if (stack.Count == 0)
                    {
                        isValid = false;
                        break;
                    }

                    if (symbol == '}' && stack.Peek()  == '{')
                    {
                        stack.Pop();
                    }
                    else if (symbol == ']' && stack.Peek() == '[')
                    {
                        stack.Pop();
                    }
                    else if (symbol == ')' && stack.Peek() == '(')
                    {
                        stack.Pop();
                    }
                    else
                    {
                        isValid = false;
                    }
                }
            }

            if (isValid)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
