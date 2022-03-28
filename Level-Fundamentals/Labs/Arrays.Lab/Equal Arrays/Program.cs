using System;
using System.Linq;

namespace Equal_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            string text1 = Console.ReadLine();
            string[] text1AsArray = text1.Split();
            int[] firstArray = text1AsArray.Select(int.Parse).ToArray();

            string text2 = Console.ReadLine();
            string[] text2AsArray = text2.Split();
            int[] secondArray = text2AsArray.Select(int.Parse).ToArray();

            int sum = 0;

            for (int i = 0; i < firstArray.Length; i++)
            {
                if (firstArray[i] == secondArray[i])
                {
                    sum += firstArray[i];
                }
                else
                {
                    Console.WriteLine($"Arrays are not identical. Found difference at {i} index");
                    return;
                }
            }
            Console.WriteLine($"Arrays are identical. Sum: {sum}");
        }
    }
}

