using System;
using System.Linq;
using System.Collections.Generic;

namespace Memory_Game
{
    internal class Program
    {
        static void Main()
        {
            List<string> values = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string command = Console.ReadLine();

            int movesCounter = 0;
            while (true)
            {

                if (command == "end" && values.Count > 0)
                {
                    Console.WriteLine("Sorry you lose :(");
                    Console.WriteLine(String.Join(" ", values));
                    break;
                }
                if (command == "end")
                {
                    break;
                }

                string[] cmdArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                int firstIndex = int.Parse(cmdArgs[0]);
                int secondIndex = int.Parse(cmdArgs[1]);

                if (firstIndex >= 0 && firstIndex < values.Count
                    && secondIndex >= 0 && secondIndex < values.Count)
                {
                    if (values[firstIndex] == values[secondIndex])
                    {
                        movesCounter++;
                        string element1 = values.ElementAt(int.Parse(cmdArgs[0]));
                        Console.WriteLine($"Congrats! You have found matching elements - {values[firstIndex]}!");
                        values.RemoveAll(x => x.Equals(element1));
                    }
                    else if (values[firstIndex] != values[secondIndex])
                    {
                        Console.WriteLine("Try again!");
                        movesCounter++;
                    }

                    if (values.Count == 0)
                    {
                        Console.WriteLine($"You have won in {movesCounter} turns!");
                        break;
                    }
                }
                else
                {
                    movesCounter++;
                    int placeToInsert = values.Count / 2;
                    string elementToInsert = $"-{movesCounter}a";


                    if (firstIndex == secondIndex)
                    {
                        Console.WriteLine("Invalid input! Adding additional elements to the board");
                    }

                    if (firstIndex < 0 || firstIndex >= values.Count)
                    {
                        Console.WriteLine("Invalid input! Adding additional elements to the board");
                    }

                    else if (secondIndex < 0 || secondIndex >= values.Count)
                    {
                        Console.WriteLine("Invalid input! Adding additional elements to the board");
                    }
                    for (int i = 1; i <= 2; i++)
                    {
                        values.Insert(placeToInsert, elementToInsert);
                    }

                }
                command = Console.ReadLine();
            }


        }
    }
}
