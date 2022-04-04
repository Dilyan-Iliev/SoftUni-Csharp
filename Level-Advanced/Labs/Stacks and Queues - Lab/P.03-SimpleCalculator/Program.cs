using System;
using System.Collections.Generic;
using System.Linq;

namespace P._03_SimpleCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            Stack<string> stack = new Stack<string>(input.Reverse());

            while (stack.Count != 1)
            {
                int num1 = int.Parse(stack.Pop()); //вземам последния елемент в stack-a , който ще е число
                char @operator = char.Parse(stack.Pop()); //вземам последния елемент в stack-a, който е оператор
                int num2 = int.Parse(stack.Pop()); //вземам последния елемент в stack-a, който е число

                if (@operator == '+')
                {
                    stack.Push((num1 + num2).ToString());
                }
                else if (@operator == '-')
                {
                    stack.Push((num1-num2).ToString());
                }
            }
            Console.WriteLine(stack.Peek());
        }
    }
}
