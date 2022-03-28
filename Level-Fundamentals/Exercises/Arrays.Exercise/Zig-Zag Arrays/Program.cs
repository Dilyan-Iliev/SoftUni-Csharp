using System;
using System.Linq;

namespace Zig_Zag_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int elements = int.Parse(Console.ReadLine());
            int[] leftElementsArray = new int[elements]; //трябва да се напълни с елементи, колкото въвежда потребителя
            int[] rightElementsArray = new int[elements];////трябва да се напълни с елементи, колкото въвежда потребителя

            for (int i = 0; i < elements; i++)
            {
                int[] loopArray = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray(); 
                if (i % 2 == 0) 
                {
                    leftElementsArray[i] = loopArray[0];
                    rightElementsArray[i] = loopArray[1];
                }
                else
                {
                    leftElementsArray[i] = loopArray[1];
                    rightElementsArray[i] = loopArray[0];
                }
            }
            Console.WriteLine(String.Join(" ",leftElementsArray));
            Console.WriteLine(String.Join(" ",rightElementsArray));
        }
    }
}
