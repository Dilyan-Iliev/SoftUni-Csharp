using System;

namespace ContactNames
{
    class Program
    {
        static void Main(string[] args)
        {
            string name1 = Console.ReadLine();
            string name2 = Console.ReadLine();
            string delimeter = Console.ReadLine();

            Console.Write($"{name1}{delimeter}{name2}");
        }
    }
}
