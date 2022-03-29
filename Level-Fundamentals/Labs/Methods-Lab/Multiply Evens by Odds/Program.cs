using System;

namespace Multiply_Evens_by_Odds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = Math.Abs(int.Parse(Console.ReadLine())); //така се подсигурявам ако ми се подаде отрицателно число
            int result = GetSumOfEvenDigits(number) * GetSumOfOddDigits(number);
            Console.WriteLine(result);
        }



        static int GetSumOfEvenDigits(int number)
        {
            int evenDigitsSum = 0;

            while (number > 0) //намаляване на числото чрез модулно деление и цикълът се върти докато не остане 1 число
            {
                int lastDigit = number % 10; //правя променлива, която пази последното число
                number /= 10; // вече числото е с 1 индекс по-малко
                if (lastDigit % 2 == 0)
                {
                    evenDigitsSum += lastDigit;
                }
            }
            return evenDigitsSum;
        }

        static int GetSumOfOddDigits(int number)
        {
            int oddDigitsSum = 0;

            while (number > 0)
            {
                int lastDigit = number % 10;
                number /= 10; //number = number / 10;

                if (lastDigit % 2 != 0)
                {
                    oddDigitsSum += lastDigit;
                }
            }
            return oddDigitsSum;
        }
    }
}
