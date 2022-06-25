using System;
using System.Linq;
using System.Collections.Generic;

namespace P._01
{
    public class StartUp
    {
        private const int Sink = 40;
        private const int Oven = 50;
        private const int Countertop = 60;
        private const int Wall = 70;
        private const int Floor = 0;

        private static int sinkCounter = 0;
        private static int ovenCounter = 0;
        private static int countertopCounter = 0;
        private static int wallCounter = 0;
        private static int floorCounter = 0;

        private static string current = string.Empty;

        private static Dictionary<string, int> dictionary = new Dictionary<string, int>()
        {
            { "Sink", 0 },
            { "Oven", 0 },
            { "Countertop", 0 },
            { "Wall", 0 },
            { "Floor", 0 }
        };

        static void Main(string[] args)
        {
            Stack<int> white = new Stack<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            Queue<int> grey = new Queue<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            while (white.Any() && grey.Any())
            {
                var currentWhite = white.Peek();
                var currentGrey = grey.Peek();

                if (currentWhite == currentGrey)
                {
                    int sum = currentWhite + currentGrey;

                    if (CheckForCoincedence(sum))
                    {
                        dictionary[current]++;

                    }
                    else
                    {
                        dictionary[current]++;
                    }
                    white.Pop();
                    grey.Dequeue();
                }
                else if (currentWhite != currentGrey)
                {
                    currentWhite /= 2;
                    white.Pop();
                    white.Push(currentWhite);

                    grey.Dequeue();
                    grey.Enqueue(currentGrey);
                }
            }

            if (!white.Any())
            {
                Console.WriteLine("White tiles left: none");
            }
            else if (white.Any())
            {
                Console.WriteLine($"White tiles left: {string.Join(", ", white)}");
            }

            if (!grey.Any())
            {
                Console.WriteLine("Grey tiles left: none");
            }
            else if (grey.Any())
            {
                Console.WriteLine($"Grey tiles left: {string.Join(", ", grey)}");
            }

            foreach (var item in dictionary.Where(x => x.Value > 0)
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }

        static bool CheckForCoincedence(int sum)
        {
            if (sum == Sink)
            {
                current = "Sink";
                sinkCounter++;
                return true;
            }
            else if (sum == Oven)
            {
                current = "Oven";
                ovenCounter++;
                return true;
            }
            else if (sum == Countertop)
            {
                current = "Countertop";
                countertopCounter++;
                return true;
            }
            else if (sum == Wall)
            {
                current = "Wall";
                wallCounter++;
                return true;
            }

            current = "Floor";
            floorCounter++;
            return false; //-> means Floor
        }
    }
}
