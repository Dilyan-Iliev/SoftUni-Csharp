using System;
using System.Collections.Generic;
using System.Linq;

namespace P._01_TheFightForGondor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int orcWaves = int.Parse(Console.ReadLine());
            var aragornDefense = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse);

            Queue<int> defenseQueue = new Queue<int>(aragornDefense);
            Stack<int> orcs = new Stack<int>();

            for (int i = 1; i <= orcWaves; i++)
            {
                var orcWariors = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse);

                if (!defenseQueue.Any())
                {
                    break;
                }

                orcs = new Stack<int>(orcWariors);

                if (i % 3 == 0)
                {
                    int additionalDefense = int.Parse(Console.ReadLine());
                    defenseQueue.Enqueue(additionalDefense);
                }

                while (defenseQueue.Any() && orcs.Any())
                {
                    int currentOrc = orcs.Peek();
                    int currentDeffence = defenseQueue.Peek();

                    if (currentOrc > currentDeffence)
                    {
                        currentOrc -= currentDeffence;
                        defenseQueue.Dequeue();
                        orcs.Pop();
                        orcs.Push(currentOrc);
                    }
                    else if (currentDeffence == currentOrc)
                    {
                        defenseQueue.Dequeue();
                        orcs.Pop();
                    }
                    else if (currentDeffence > currentOrc)
                    {
                        currentDeffence -= currentOrc;
                        orcs.Pop(); //because current orc dies
                        defenseQueue.Dequeue();
                        int itterations = defenseQueue.Count;
                        defenseQueue.Enqueue(currentDeffence);

                        for (int k = 0; k < itterations; k++)
                        {
                            int elementOut = defenseQueue.Dequeue();
                            defenseQueue.Enqueue(elementOut);
                        }
                    }
                }
            }

            if (!defenseQueue.Any())
            {
                Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
                Console.WriteLine($"Orcs left: {string.Join(", ", orcs)}");
            }
            else if (!orcs.Any())
            {
                Console.WriteLine("The people successfully repulsed the orc's attack.");
                Console.WriteLine($"Plates left: {string.Join(", ", defenseQueue)}");
            }
        }
    }
}
