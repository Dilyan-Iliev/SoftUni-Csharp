using System;

namespace P._04_FixingVol2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNumber, secondNumber;
            int result;

            firstNumber = 30;
            secondNumber = 60;
            result = Convert.ToInt32(firstNumber * secondNumber);
            Console.WriteLine($"{firstNumber} x {secondNumber} = {result}");
            
        }
    }
}
