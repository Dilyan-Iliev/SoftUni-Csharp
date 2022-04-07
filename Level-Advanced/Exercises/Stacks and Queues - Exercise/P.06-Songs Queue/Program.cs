using System;
using System.Linq;
using System.Collections.Generic;

namespace P._06_Songs_Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] songs = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            Queue<string> queue = new Queue<string>(songs);

            while (queue.Any()) //if it returns false - it means 0 songs in the queue
            {
                string[] command = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string currentCmd = command[0];

                if (currentCmd == "Play")
                {
                    PlayCmd(queue);
                }
                else if (currentCmd == "Add")
                {
                    int index = string.Join(" ",command).IndexOf(' ');
                    string substring = string.Join(" ",command).Substring(index + 1);
                    string songToAdd = substring;
                    AddCmd(queue, songToAdd);
                }
                else if (currentCmd == "Show")
                {
                    ShowCmd(queue);
                }
            }

            Console.WriteLine("No more songs!");
        }

        static Queue<string> PlayCmd(Queue<string> queue)
        {
            queue.Dequeue();

            return queue;
        }

        static Queue<string> AddCmd(Queue<string> queue, string songToAdd)
        {
            if (!queue.Contains(songToAdd))
            {
                queue.Enqueue(songToAdd);
                return queue;
            }

            Console.WriteLine($"{songToAdd} is already contained!");
            return queue;
        }

        static Queue<string> ShowCmd(Queue<string> queue)
        {
            Console.WriteLine(string.Join(", ", queue));

            return queue;
        }
    }
}
