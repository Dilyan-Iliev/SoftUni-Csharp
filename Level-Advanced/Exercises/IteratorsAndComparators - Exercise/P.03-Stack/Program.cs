using System;
using System.Linq;

namespace P._03_Stack
{
    public class Program
    {
        static void Main(string[] args)
        {
            var obj = new CustomClass<string>();

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] cmdArgs = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string currentCmd = cmdArgs[0];

                if (currentCmd == "Push")
                {
                    string[] elements = cmdArgs
                        .Skip(1)
                        .Select(x => x.Split(",").First())
                        .ToArray();

                    obj.Push(elements);
                }
                else if (currentCmd == "Pop")
                {
                    obj.Pop();
                }
            }

            foreach (var element in obj)
            {
                Console.WriteLine(element);
            }
            foreach (var element in obj)
            {
                Console.WriteLine(element);
            }
        }
    }
}
