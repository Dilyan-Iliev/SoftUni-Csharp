using System;

namespace Add_and_Subtract
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number1 = int.Parse(Console.ReadLine());
            int number2 = int.Parse(Console.ReadLine());
            int number3 = int.Parse(Console.ReadLine());
            int sumResult = Sum(number1, number2);
            int subsResult = Substract(sumResult, number3);
            Console.WriteLine(subsResult);
        }

        static int Sum(int num1, int num2)
        {
            int result = num1 + num2;
            return result;
        }

        static int Substract(int sumResult, int num3)//1ят параметър е резултат от Sum метод ; 2я параметър ще се чете от конзолата (number3)
        {
            int result = sumResult - num3;
            return result;
        }
    }
}
