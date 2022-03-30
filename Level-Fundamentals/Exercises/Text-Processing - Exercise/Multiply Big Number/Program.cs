using System;
using System.Numerics;

namespace Multiply_Big_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var sum = new BigInteger();
            BigInteger firstNum = BigInteger.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            sum = firstNum * secondNum;
            Console.WriteLine(sum);
        }
    }
}
