using System;
using System.Linq;
using System.Collections.Generic;

namespace P._01_Bombs
{
    internal class Program
    {
        const int daturaBomb = 40;
        const int cherryBomb = 60;
        const int smokeDecoyBomb = 120;

        public static int daturaCounter = 0;
        public static int cherryCounter = 0;
        public static int smokeCounter = 0;

        public static string currentBomb = string.Empty;
        static void Main()
        {
            int[] bombEffects = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] bombCasing = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> bombEffectsQueue = new Queue<int>(bombEffects);
            Stack<int> bombCasingStack = new Stack<int>(bombCasing);
            Dictionary<string, int> bombs = new Dictionary<string, int>()
            {
                { "Cherry Bombs", 0 },
                { "Datura Bombs", 0 },
                { "Smoke Decoy Bombs", 0 }
            };

            bool enoughBombs = false;

            while (bombEffectsQueue.Any() && bombCasingStack.Any())
            {
                int currentBombEffeect = bombEffectsQueue.Peek();
                int currentBombCasingEffeect = bombCasingStack.Peek();

                int sum = currentBombEffeect + currentBombCasingEffeect;

                if (CheckForMathchingBomb(sum))
                {
                    bombEffectsQueue.Dequeue();
                    bombCasingStack.Pop();


                    if (bombs.ContainsKey(currentBomb))
                    {
                        bombs[currentBomb]++;
                    }
                }
                else
                {
                    var bomb = bombCasingStack.Pop() - 5;
                    bombCasingStack.Push(bomb);
                }

                if (daturaCounter >= 3 && cherryCounter >= 3 && smokeCounter >= 3)
                {
                    enoughBombs = true;
                    break;
                }
            }

            PrintOutput(enoughBombs, bombs, bombEffectsQueue, bombCasingStack);
        }

        static void PrintOutput(bool enoughBombs, Dictionary<string, int> bombs,
            Queue<int> bombEffectsQueue, Stack<int> bombCasingStack)
        {
            if (enoughBombs)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }

            if (bombEffectsQueue.Any())
            {
                Console.WriteLine($"Bomb Effects: {string.Join(", ", bombEffectsQueue)}");
            }
            else
            {
                Console.WriteLine("Bomb Effects: empty");
            }

            if (bombCasingStack.Any())
            {
                Console.WriteLine($"Bomb Casings: {string.Join(", ", bombCasingStack)}");
            }
            else
            {
                Console.WriteLine("Bomb Casings: empty");
            }

            foreach (var kvp in bombs.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
        }

        static bool CheckForMathchingBomb(int sum)
        {
            if (sum == daturaBomb)
            {
                currentBomb = "Datura Bombs";
                daturaCounter++;
                return true;
            }
            else if (sum == cherryBomb)
            {
                currentBomb = "Cherry Bombs";
                cherryCounter++;
                return true;
            }
            else if (sum == smokeDecoyBomb)
            {
                currentBomb = "Smoke Decoy Bombs";
                smokeCounter++;
                return true;
            }

            return false;
        }
    }
}
