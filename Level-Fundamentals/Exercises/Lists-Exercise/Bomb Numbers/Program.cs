using System;
using System.Linq;
using System.Collections.Generic;

namespace Bomb_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int[] bombNums = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int specialBombNumber = bombNums[0];
            int power = bombNums[1];

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] == specialBombNumber)
                {
                    for (int k = 1; k <= power; k++)
                    {
                        if (i - k < 0)
                        {
                            break;
                        }
                        else
                        {
                            numbers[i - k] = 0;
                        }
                    }

                    for (int j = 1; j <= power; j++)
                    {
                        if (i + j > numbers.Count-1)
                        {
                            break;
                        }
                        else
                        {
                            numbers[i + j] = 0;
                        }
                    }
                    numbers[i] = 0;
                }

            }
            int sum = numbers.Sum();
            Console.WriteLine(sum);

        }
    }
}
