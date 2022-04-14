using System;
using System.Collections.Generic;

namespace P._01_Unique_Usernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfLines = int.Parse(Console.ReadLine());

            HashSet<string> names = new HashSet<string>();

            for (int i = 1; i <= numberOfLines; i++)
            {
                string name = Console.ReadLine();
                names.Add(name);
            }
            Console.WriteLine(string.Join(Environment.NewLine, names));
        }
    }
}
