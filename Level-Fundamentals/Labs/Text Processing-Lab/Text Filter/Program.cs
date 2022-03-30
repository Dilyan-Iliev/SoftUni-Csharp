using System;

namespace Text_Filter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] bannedWords = Console.ReadLine().Split(", ");
            string textToFilter = Console.ReadLine();

            foreach (var word in bannedWords)
            {
                string wordToPut = new string('*', word.Length);
                textToFilter = textToFilter.Replace(word, wordToPut);
            }
            Console.WriteLine(textToFilter);
        }
    }
}
