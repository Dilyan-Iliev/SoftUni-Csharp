using System;

namespace P._01_Action_Point
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            
            Action<string[]> action = PrintResultOnNewLines; //присвоявам метода на абстрактен action
            action(names); //извиквам метода с names - същото ще е ако кажа PrintResultOnNewLines(names)
        }

        static void PrintResultOnNewLines(string[] names)
        {
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}
