using System;
using System.Linq;

namespace Even_and_Odd_Subtraction
{
    class Program
    {
        static void Main(string[] args)
        {
            //string text = Console.ReadLine();
            //string[] textAsArray = text.Split();
            //int[] num = textAsArray.Select(int.Parse).ToArray();

            //int oddSum = 0;
            //int evenSum = 0;

            //for (int i = 0; i < textAsArray.Length; i++)
            //{
            //    if (num[i] % 2 == 0)
            //    {
            //        evenSum += num[i];
            //    }
            //    else
            //    {
            //        oddSum += num[i];
            //    }
            //}
            //int result = evenSum - oddSum;
            //Console.WriteLine(result);


            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int evenSum = 0;
            int oddSum = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 == 0)
                {
                    evenSum += numbers[i];
                }
                else
                {
                    oddSum += numbers[i];
                }
            }
            int result = evenSum - oddSum;
            Console.WriteLine(result);
        }
    }
}
