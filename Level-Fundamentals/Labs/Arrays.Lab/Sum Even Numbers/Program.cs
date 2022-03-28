using System;
using System.Linq;

namespace Sum_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string[] textAsArray = text.Split();
            int[] numbers = textAsArray.Select(int.Parse).ToArray();

            int evenSum = 0;
            for (int i = 0; i < textAsArray.Length; i++)
            {
                if (numbers[i] % 2 == 0)
                {
                    evenSum += numbers[i];
                }
            }
            Console.WriteLine(evenSum);
        }
    }
}
