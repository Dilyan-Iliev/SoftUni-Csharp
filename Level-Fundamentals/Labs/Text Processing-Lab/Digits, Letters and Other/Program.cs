using System;

namespace Digits__Letters_and_Other
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string letters = string.Empty;
            string digits = string.Empty;
            string otherSymbols = string.Empty;

            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsLetter(input[i]))
                {
                    letters+=input[i];
                }
                else if (char.IsDigit(input[i]))
                {
                    digits+=input[i];
                }
                else 
                {
                    otherSymbols+=input[i];
                }
            }
            Console.WriteLine(digits);
            Console.WriteLine(letters);
            Console.WriteLine(otherSymbols);
        }
    }
}
