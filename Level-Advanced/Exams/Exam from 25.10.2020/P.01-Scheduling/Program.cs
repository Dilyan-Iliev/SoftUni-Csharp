using System;
using System.Linq;
using System.Collections.Generic;

namespace P._01_Scheduling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] tasks = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] threads = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int taskToKill = int.Parse(Console.ReadLine());

            Stack<int> tasksStack = new Stack<int>(tasks);
            Queue<int> threadsQueue = new Queue<int>(threads);

            int threadKilledTask = 0;

            while (tasksStack.Any() && threadsQueue.Any())
            {
                int currentTask = tasksStack.Peek();
                int currentThread = threadsQueue.Peek();

                if (currentThread >= currentTask)
                {
                    tasksStack.Pop();
                    threadsQueue.Dequeue();
                }
                else if (currentThread < currentTask)
                {
                    threadsQueue.Dequeue();
                }

                currentTask = tasksStack.Peek();
                currentThread = threadsQueue.Peek();

                if (currentTask == taskToKill)
                {
                    threadKilledTask = currentThread;
                    break;
                }
            }

            Console.WriteLine($"Thread with value {threadKilledTask} killed task {taskToKill}");
            Console.WriteLine(string.Join(" ", threadsQueue));
        }
    }
}
