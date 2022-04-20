using System;
using System.Linq;

namespace P._03_Count_Uppercase_Words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] text = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Func<string, bool> predicate = x => char.IsUpper(x[0]);

            foreach (var word in text)
            {
                if (predicate(word))
                {
                    Console.WriteLine(word);
                }
            }
        }
    }
}
