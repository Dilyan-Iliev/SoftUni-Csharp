using System;
using System.Linq;

namespace Top_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            for (int i = 0; i < numbers.Length; i++)
            {
                bool isBigger = true;
                for (int k = i+1 ; k < numbers.Length; k++)//правим i+1 , за да сравняваме i със следващата цифра в масива
                {
                    if (numbers[i] <= numbers[k])
                    {
                        isBigger = false;
                    }
                }
                if (isBigger)
                {
                    Console.Write(numbers[i] + " ");
                }
            }
            
        }
    }
}
