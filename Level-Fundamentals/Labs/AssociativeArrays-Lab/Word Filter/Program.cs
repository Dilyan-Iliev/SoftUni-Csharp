using System;
using System.Linq;

namespace Word_Filter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string[] words = Console.ReadLine().Split(' ');
            //var orderedWords = words.Where(x => x.Length %2 == 0).ToArray();
            //foreach (var word in orderedWords)
            //{
            //    Console.WriteLine(word);
            //}

            string[] words = Console.ReadLine()
                .Split(' ')
                .Where(x => x.Length % 2 == 0)
                .ToArray();
            foreach (var word in words)
            {
                Console.WriteLine(word);
            }

        }
    }
}
