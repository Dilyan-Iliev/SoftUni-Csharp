using System;
using System.Collections.Generic;
using System.Linq;

namespace P._02_Basic_Queue_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbersToManipulateTheQueuekWith = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] numbersForTheQueue = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Queue<int> queue = new Queue<int>();

            int numberOfIterationsToEnqueue = numbersToManipulateTheQueuekWith[0];

            for (int i = 0; i < numberOfIterationsToEnqueue; i++)
            {
                queue.Enqueue(numbersForTheQueue[i]);
            }

            int numberOfIterationsToDequeue = numbersToManipulateTheQueuekWith[1];

            for (int i = 0; i < numberOfIterationsToDequeue; i++)
            {
                queue.Dequeue();
            }

            int numberToLookForInTheQueue = numbersToManipulateTheQueuekWith[2];

            if (queue.Contains(numberToLookForInTheQueue))
            {
                Console.WriteLine("true");
            }
            else if (queue.Count == 0)
            {
                Console.WriteLine(0);
            }
            else if (!queue.Contains(numberToLookForInTheQueue))
            {
                int smallestElementInTheStack = queue.Min();
                Console.WriteLine(smallestElementInTheStack);
            }
        }
    }
}
