using System;

namespace Smallest_of_Three_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int mainMethodNumber1 = int.Parse(Console.ReadLine());
            int mainMethodNumber2 = int.Parse(Console.ReadLine());
            int mainMethodNumber3 = int.Parse(Console.ReadLine());
            NumberComparison(mainMethodNumber1, mainMethodNumber2, mainMethodNumber3);

            //int result = NumbersComparison(mainMethodNumber1, mainMethodNumber2, mainMethodNumber3);
            //Console.WriteLine(result);
        }

        static void NumberComparison(int number1, int number2, int number3)
        {
            if (number1 <= number2 && number1 <= number3)
            {
                Console.WriteLine(number1);
            }
            else if (number2 <= number1 && number2 <= number3)
            {
                Console.WriteLine(number2);
            }
            else if (number3 <= number2 && number3 <= number1)
            {
                Console.WriteLine(number3);
            }
        }

        static int NumbersComparison(int number1, int number2, int number3) //може и с такъв метод да се направи 
        {
            if (number1 <= number2 && number1 <= number3)
            {
                return number1;
            }
            else if (number2 <= number1 && number2 <= number3)
            {
                return number2;
            }
            else //if (number3 <= number2 && number3 <= number1)
            {
                return number3;
            }
        }
    }
}
