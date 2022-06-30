using System;
using System.Collections.Generic;

namespace _02.EnterNumbers
{
    class Program
    {
        static void Main()
        {
            int start = 1;
            int end = 100;
            int num = 0;

            try
            {
                num = ReadNumber(start, end);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static int ReadNumber(int start, int end)
        {
            int previousNumber = 0;

            for (int i = 1; i <= 10; i++)
            {
                string input = Console.ReadLine();

                bool parsing = int.TryParse(input, out int number);
                if (!parsing)
                {
                    throw new FormatException("Invalid Number!");
                }

                previousNumber = number;
                if (number < previousNumber || number <= start || number >= end)
                {
                    throw new ArgumentOutOfRangeException("number", $"Your number is not in range {previousNumber} - {end}");
                }
            }

            return previousNumber;
        }
    }
}