using System;
using System.Linq;

namespace Replace_Repeating_Chars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var word = Console.ReadLine().ToList();
            for (int i = 0; i < word.Count-1; i++)
            {
                if (word[i] == word[i + 1]) //проверявам дали текущия индекс е равен на следващия
                {
                    word.RemoveAt(i); //премахвам текущия индекс
                    i--; // връщам се с 1 итерация назад
                }
            }
            Console.WriteLine(string.Join("",word));
        }
    }
}
