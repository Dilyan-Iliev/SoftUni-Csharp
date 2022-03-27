using System;

namespace From_Left_to_the_Right
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //from More Exercises

            int numberOfLines = int.Parse(Console.ReadLine()); // колко броя двойки числа ще се въведат

            
            for (int i = 0; i < numberOfLines; i++)
            {
                string numbers = Console.ReadLine(); //чета string, което е някакво число

                string[] numbersAsArray = numbers.Split(); //правя го на масив, който го сплитвам 

                long leftNumber = long.Parse(numbersAsArray[0]); //правя Math.Abs понеже може да ми въведат и отрицателно число
                long rightNumber =long.Parse(numbersAsArray[1]);

                long sumOfDigits = 0;
                if (leftNumber > rightNumber)
                {
                    while (leftNumber!=0)
                    {
                        sumOfDigits += leftNumber % 10;
                        leftNumber /= 10;
                    }
                }
                else //if (rightNumber > leftNumber)
                {
                    while (rightNumber != 0)
                    {
                        sumOfDigits += rightNumber%10;
                        rightNumber /= 10;
                    }
                }

                Console.WriteLine($"{Math.Abs(sumOfDigits)}");   
            }
        }
    }
}
