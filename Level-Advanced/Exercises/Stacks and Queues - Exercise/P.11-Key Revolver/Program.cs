using System;
using System.Linq;
using System.Collections.Generic;

namespace P._11_Key_Revolver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int gunBarrelSize = int.Parse(Console.ReadLine());

            int originBarrelSize = gunBarrelSize;

            int[] bullets = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] locks = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int recipeValue = int.Parse(Console.ReadLine());

            Queue<int> locksQueue = new Queue<int>(locks); //enqueue each element of the 1st array into the queue
            Stack<int> bulletsStack = new Stack<int>(bullets); //push each element of the 2nd array into the stack

            int shotBulletsCounter = 0;

            while (locksQueue.Any() && bulletsStack.Any())
            {
                int currentBullet = bulletsStack.Peek();
                int currentLock = locksQueue.Peek();

                if (currentBullet <= currentLock)
                {
                    Console.WriteLine("Bang!");
                    locksQueue.Dequeue();
                    //bulletsStack.Pop();
                }
                else
                {
                    Console.WriteLine("Ping!");
                    //bulletsStack.Pop();
                }

                bulletsStack.Pop();
                gunBarrelSize--;
                shotBulletsCounter++;

                if (gunBarrelSize == 0 && bulletsStack.Count != 0)
                {
                    gunBarrelSize = originBarrelSize;
                    Console.WriteLine("Reloading!");
                }
            }
            int shotBulletsSum = shotBulletsCounter * bulletPrice;
            int moneyEarned = recipeValue - shotBulletsSum;

            if (locksQueue.Any())
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locksQueue.Count}");
            }
            else
            {
                Console.WriteLine($"{bulletsStack.Count} bullets left. Earned ${moneyEarned}");
            }
        }
    }
}
