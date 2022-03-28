using System;
using System.Linq;

namespace Condense_Array_to_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] mainArray = Console.ReadLine().Split().Select(int.Parse).ToArray();

            while (mainArray.Length > 1)
            {
                int[] secondArray = new int[mainArray.Length - 1];
                for (int i = 0; i < mainArray.Length - 1; i++)
                {
                    secondArray[i] = mainArray[i] + mainArray[i + 1];
                }
                mainArray = secondArray;
            }
            Console.WriteLine(mainArray[0]);

        }

    }

}

