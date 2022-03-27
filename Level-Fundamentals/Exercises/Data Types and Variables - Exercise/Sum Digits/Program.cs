using System;

namespace Sum_Digits
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int sumOfDigits = 0; //ще получи стойността от 17ти ред

            int numLastDigit;

            while (num > 0)
            {
                numLastDigit = num % 10;
                sumOfDigits += numLastDigit;
                num = num / 10; //-> вземам последната цифра на числото и остават останалите цифри
            }
            Console.WriteLine(sumOfDigits);
        }
    }
}
