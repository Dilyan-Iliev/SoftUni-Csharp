using System;
using System.Linq;
using System.Collections.Generic;

namespace Shoot_for_the_Win
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] targets = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string command;
            int shotTargetsCounter = 0;

            while ((command = Console.ReadLine()) != "End")
            {
                int targetAsIndex = int.Parse(command);

                if (targetAsIndex < 0 || targetAsIndex > targets.Length - 1)
                {
                    continue;
                }
                else
                {
                    int currentTarget = targets[targetAsIndex];
                    //int currentIndex = targetAsIndex;

                    for (int i = 0; i < targets.Length; i++)
                    {
                        if (targets[i] == currentTarget && targetAsIndex == i)
                        {
                            targets[targetAsIndex] = -1;
                            shotTargetsCounter++;
                            continue;
                        }
                        else
                        {
                            if (targets[i] <= currentTarget)
                            {
                                if (targets[i] == -1)
                                {
                                    continue;
                                }
                                targets[i] += currentTarget;
                            }
                            else if (targets[i] > currentTarget)
                            {
                                if (targets[i] == -1)
                                {
                                    continue;
                                }
                                targets[i] -= currentTarget;
                            }
                        }
                    }
                }
            }

            Console.WriteLine($"Shot targets: {shotTargetsCounter} -> {string.Join(" ", targets)}");

            //OR with List:

            //List<int> targets = Console.ReadLine()
            //    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            //    .Select(int.Parse)
            //    .ToList();

            //string command;
            //int shotTargetsCounter = 0;

            //while ((command = Console.ReadLine()) != "End")
            //{
            //    int targetAsIndex = int.Parse(command);

            //    if (targetAsIndex < 0 || targetAsIndex > targets.Count - 1)
            //    {
            //        continue;
            //    }
            //    else
            //    {
            //        int currentTarget = targets[targetAsIndex];
            //        //int currentIndex = targetAsIndex;

            //        for (int i = 0; i < targets.Count; i++)
            //        {
            //            if (targets[i] == currentTarget && targetAsIndex == i)
            //            {
            //                targets[targetAsIndex] = -1;
            //                shotTargetsCounter++;
            //                continue;
            //            }
            //            else
            //            {
            //                if (targets[i] <= currentTarget)
            //                {
            //                    if (targets[i] == -1)
            //                    {
            //                        continue;
            //                    }
            //                    targets[i] += currentTarget;
            //                }
            //                else if (targets[i] > currentTarget)
            //                {
            //                    if (targets[i] == -1)
            //                    {
            //                        continue;
            //                    }
            //                    targets[i] -= currentTarget;
            //                }
            //            }
            //        }
            //    }
            //}

            //Console.WriteLine($"Shot targets: {shotTargetsCounter} -> {string.Join(" ", targets)}");
        }
    }
}
