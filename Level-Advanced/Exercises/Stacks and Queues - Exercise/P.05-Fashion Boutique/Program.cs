using System;
using System.Linq;
using System.Collections.Generic;

namespace P._05_Fashion_Boutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] clothesInABox = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int singleRackCapacity = int.Parse(Console.ReadLine());

            Stack<int> stack = new Stack<int>(clothesInABox);

            int racksCounter = 1;
            int clothesSum = 0;

            while (stack.Count > 0)
            {
                int currentState = stack.Pop(); //броя на дрехите на съответната итерация
                bool isFull = clothesSum + currentState <= singleRackCapacity;

                if (isFull)
                {
                    clothesSum += currentState;
                }
                else
                {
                    clothesSum = currentState;
                    racksCounter++;
                }
            }
            Console.WriteLine(racksCounter);
        }
    }
}
