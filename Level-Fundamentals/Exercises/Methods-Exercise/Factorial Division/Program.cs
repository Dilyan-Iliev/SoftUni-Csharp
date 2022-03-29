using System;

namespace Factorial_Division
{
    internal class Program
    {
        static void Main(string[] args)
        {
            long number = long.Parse(Console.ReadLine());
            long number2 = long.Parse(Console.ReadLine());
            long result1 = FactorialFirstNumber(number);
            long result2 = FactorialSecondNumber(number2);
            double finalResult = (double)result1 / result2;
            Console.WriteLine($"{finalResult:F2}");

        }

        static long FactorialFirstNumber(long number)
        {
            long factorial = 1;
            for (int i = 1; i <= number; i++)
            {
                factorial *= i;
            }
            return factorial;
        }

        static long FactorialSecondNumber(long number)
        {
            long factorial = 1;
            for (int i = 1; i <= number; i++)
            {
                factorial *= i;
            }
            return factorial;
        }
    }
}
