using System;
using System.Text;

namespace Reverse_Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                var sb = new StringBuilder();

                for (int i = input.Length - 1; i >= 0; i--)
                {
                    sb.Append(input[i]);
                }

                Console.WriteLine($"{input} = {sb.ToString()}");
            }

            //or

            //string input;
            //while ((input = Console.ReadLine()) != "end")
            //{
            //    string reversedInput = string.Empty;

            //    for (int i = input.Length - 1; i >= 0; i--)
            //    {
            //        reversedInput += input[i];
            //    }

            //    Console.WriteLine($"{input} = {reversedInput}");
            //}
        }
    }
}
