using System;
using System.Linq;
using System.Collections.Generic;

namespace P._01_Basic_Stack_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbersToManipulateTheStackWith = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] numbersForTheStack = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Stack<int> stack = new Stack<int>();

            int numberOfIterationsToPush = numbersToManipulateTheStackWith[0];

            for (int i = 0; i < numberOfIterationsToPush; i++)
            {
                stack.Push(numbersForTheStack[i]);
            }

            int numberOfIterationsToPop = numbersToManipulateTheStackWith[1];

            for (int i = 0; i < numberOfIterationsToPop; i++)
            {            
                    stack.Pop();
            }

            int numberToLookForInTheStack = numbersToManipulateTheStackWith[2];

            if (stack.Contains(numberToLookForInTheStack))
            {
                Console.WriteLine("true");
            }
            else if (stack.Count == 0)
            {
                Console.WriteLine(0);
            }
            else if (!stack.Contains(numberToLookForInTheStack))
            {
                int smallestElementInTheStack = stack.Min();
                Console.WriteLine(smallestElementInTheStack);
            }

            //var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            //int pushCount = input[0];
            //int popCount = input[1];
            //int element = input[2];

            //var elements = Console.ReadLine().Split().Select(int.Parse).ToArray();
            //var stack = new Stack<int>();

            //for (int i = 0; i < pushCount; i++)
            //{
            //    stack.Push(elements[i]);
            //}

            //for (int i = 0; i < popCount; i++)
            //{
            //    stack.Pop();
            //}

            //if (stack.Contains(element))
            //{
            //    Console.WriteLine("true");
            //}
            //else
            //{
            //    if (stack.Count == 0)
            //    {
            //        Console.WriteLine(0);
            //    }
            //    else
            //    {
            //        Console.WriteLine(stack.Min());
            //    }
            //}
        }
    }
}
