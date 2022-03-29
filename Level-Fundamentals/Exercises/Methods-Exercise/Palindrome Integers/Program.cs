using System;

namespace Palindrome_Integers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = ""; //задавам го празен, понеже във CheckReversedNumber въвеждам вход
            CheckReversedNumber(input);
        }

        static void CheckReversedNumber(string number)
        {
            string reversed = string.Empty;
            string input = Console.ReadLine();

            while (input != "END")
            {

                for (int i = input.Length - 1; i >= 0; i--)
                {
                    reversed += input[i];
                }

                if (reversed == input)
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine("false");
                }
                reversed = string.Empty;
                input = Console.ReadLine();
            }
        }

    }
}
