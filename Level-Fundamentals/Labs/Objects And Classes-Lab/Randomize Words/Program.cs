using System;
using System.Linq;
using System.Collections.Generic;

namespace Randomize_Words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split().ToArray();

            var random = new Random();

            for (int i = 0; i < words.Length; i++)
            {
                int randomIndex = random.Next(0, words.Length - 1); //определя случаен индекс в интервала от 0 до words.Lenght-1
                string a = words[randomIndex]; // a = words от случаен индекс избран от горния ред
                string b = words[i]; // b = текущия индекс от i
                words[randomIndex] = b; // разменяме местата на a и b във масива.
                words[i] = a;
            }
            foreach (var word in words)
            {
                Console.WriteLine(word);
            }
        }
    }
}
