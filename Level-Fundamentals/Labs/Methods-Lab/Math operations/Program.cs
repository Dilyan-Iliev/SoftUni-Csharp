using System;

namespace Math_operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double mainMethodNumber1 = double.Parse(Console.ReadLine());
            char mainMethodOperation = char.Parse(Console.ReadLine());
            double mainMethodNumber2 = double.Parse(Console.ReadLine());
            double mainMethodResult = MathOperations(mainMethodNumber1, mainMethodOperation, mainMethodNumber2);
            Console.WriteLine(mainMethodResult);
        }

        static double MathOperations(double number1, char operation, double number2)
        {
            double result = 0;
            switch (operation)
            {
                case '/':
                    result = number1 / number2;
                    break;
                case '*':
                    result = number1 * number2;
                    break;
                case '+':
                    result = number1 + number2;
                    break;
                case '-':
                    result = number1 - number2;
                    break;
            }
            return result;
        }
    }
}
