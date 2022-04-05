using System;
using System.Linq;
using System.Collections.Generic;

namespace P._06_Supermarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();

            Queue<string> queue = new Queue<string>();
            queue.Enqueue(name);

            while (true)
            {
                name = Console.ReadLine();
                if (name == "End")
                {
                    break;
                }
                if (name == "Paid")
                {
                    Console.WriteLine(string.Join(Environment.NewLine, queue));
                    queue.Clear();
                }
                else
                {
                    queue.Enqueue(name);
                }
            }
            Console.WriteLine($"{queue.Count} people remaining.");
        }
    }
}
