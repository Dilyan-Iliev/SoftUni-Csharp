using System;
using System.Linq;

namespace Equal_Sums
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int rightSum = 0;
            int leftSum = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                leftSum += numbers[i]; //ще напълним leftSum със целия сбор на масива
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                leftSum -= numbers[i]; //почваме да изпразваме leftSum докато се изравни с rightSum

                if (leftSum == rightSum)
                {
                    Console.WriteLine(i);
                    return;
                }
                rightSum += numbers[i]; //почваме да пълним rightSum докато се изравни с leftSum
            }
            Console.WriteLine("no");
        }
    }
}
