using System;

namespace P._02_Knights_of_Honor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Action<string[]> action = AppendElement;
            action(names);
        }

        static void AppendElement(string[] names)
        {
            foreach (var name in names)
            {
                Console.WriteLine($"Sir {name}");
            }
        }
    }
}
