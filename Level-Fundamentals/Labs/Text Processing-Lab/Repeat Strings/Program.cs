using System;
using System.Text;

namespace Repeat_Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            //string result = string.Empty;

            //foreach (var word in input)
            //{
            //    int itterations = word.Length;

            //    for (int i = 0; i < itterations; i++)
            //    {
            //        result += word;
            //    }
            //}
            //Console.WriteLine(result);

            //or

            var sb = new StringBuilder();
            foreach (var word in input)
            {
                for (int i = 0; i < word.Length; i++)
                {
                    sb.Append(word);
                }
            }
            Console.WriteLine(sb.ToString());

        }
    }
}
