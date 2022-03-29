using System;

namespace Data_Types
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //from More Exercises
            string input=Console.ReadLine();

            if (input == "int")
            {
                int number = int.Parse(Console.ReadLine());
                Console.WriteLine(NumberMultiply(number));
            }
            else if (input == "real")
            {
                double number = double.Parse(Console.ReadLine());
                NumberMultiply(number);
            }
            else if (input == "string")
            {
                Surround(input);
            }
        }

        static int NumberMultiply(int number)
        {
            int result = number * 2;
            return result;
        }

        static void NumberMultiply(double number)
        {
            double result = number * 1.5;
            Console.WriteLine($"{result:F2}");
        }

        static void Surround(string text)
        {
            string input = Console.ReadLine();
          Console.WriteLine($"${input}$");
        }
    }
}
