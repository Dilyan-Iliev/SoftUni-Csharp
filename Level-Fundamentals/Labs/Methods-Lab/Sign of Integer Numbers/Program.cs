using System;

namespace Sign_of_Integer_Numbers
{
    internal class Program
    {
        static void Main(string[] args) 
        {
            int mainMethodNum = int.Parse(Console.ReadLine()); //чета вход, който е параметърът във 2я метод
            PrintNumber(mainMethodNum);
        }

        private static void PrintNumber(int number) //метод, който не връща параметри
        {
            if (number > 0)
            {
                Console.WriteLine($"The number {number} is positive.");
            }
            else if (number == 0)
            {
                Console.WriteLine($"The number {number} is zero.");
            }
            else if (number < 0)
            {
                Console.WriteLine($"The number {number} is negative.");
            }
        }
    }
}
