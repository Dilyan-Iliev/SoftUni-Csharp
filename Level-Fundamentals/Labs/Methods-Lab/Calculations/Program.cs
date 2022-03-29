using System;

namespace Calculations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string action = Console.ReadLine();
            double mainMethodNum1 = double.Parse(Console.ReadLine());
            double mainMethodNum2 = double.Parse(Console.ReadLine());
            PrintCalculations(action, mainMethodNum1, mainMethodNum2);
        }

        private static void PrintCalculations(string typeCalculation , double num1 , double num2)
        {
           double result = 0;
            switch (typeCalculation)
            {
                case "add":
                    result = num1 + num2;
                    break;
                case "multiply":
                    result = num1 * num2;
                    break;
                case "subtract":
                    result = num1 - num2;
                    break;
                case "divide":
                    result = num1 / num2;
                    break;
            }
            Console.WriteLine(result);
        }
    }
}
