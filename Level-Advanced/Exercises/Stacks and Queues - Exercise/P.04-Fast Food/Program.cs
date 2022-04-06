using System;
using System.Collections.Generic;
using System.Linq;

namespace P._04_Fast_Food
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int foodQuantity = int.Parse(Console.ReadLine());

            int[] orders = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Queue<int> queue = new Queue<int>(orders);
            Console.WriteLine(queue.Max());

            for (int i = 0; i < orders.Length; i++)
            {
                int currentOrder = orders[i];

                bool isEnoughFood = foodQuantity - currentOrder >= 0;

                if (!isEnoughFood)
                {
                    break;
                }
                else
                {
                    foodQuantity -= currentOrder;
                    queue.Dequeue();
                }
            }

            if (queue.Count > 0) //or (queue.Any())
            {
                Console.WriteLine($"Orders left: {string.Join(" ", queue)}");
            }
            else
            {
                Console.WriteLine("Orders complete");
            }
        }
    }
}
