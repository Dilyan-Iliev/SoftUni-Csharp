using System;

namespace Math_Power
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double mainMethodNumber = double.Parse(Console.ReadLine()); //инициализирам число
            double mainMethodPower = double.Parse(Console.ReadLine()); //инициализирам степен на повдигане
            double mainMethodSum = NumberRaisedToNumber(mainMethodNumber, mainMethodPower); //запазвам долняи метод променлива, за да мога да го извикам
            Console.WriteLine(mainMethodSum);//връща резултата от долния метод.
        }

        static double NumberRaisedToNumber(double number, double power) //задавам параметри, които да инициализирам в Main-a
        {
            double sum = 1;

            for (int i = 0; i < power; i++) //въртя цикъл до степента на която трябва да повдигам числото
            {
                sum *= number;
            }
            return sum; //връща като данни сумата, когато извикам този метод.
        }
    }
}
