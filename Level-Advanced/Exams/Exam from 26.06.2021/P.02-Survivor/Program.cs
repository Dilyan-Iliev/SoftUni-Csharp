using System;
using System.Linq;

namespace P._02_Survivor
{
    internal class Program
    {
        public static int collectedTokens = 0;
        public static int opponentTokens = 0;
        public static int opponentStepsInDirection = 3;
        static void Main(string[] args)
        {
            int jaggedArrayRows = int.Parse(Console.ReadLine());

            char[][] jaggedArr = new char[jaggedArrayRows][];
            JaggedArrayFill(jaggedArr);

            string input;
            while ((input = Console.ReadLine()) != "Gong")
            {
                string[] inputArgs = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string command = inputArgs[0];
                int row = int.Parse(inputArgs[1]);
                int col = int.Parse(inputArgs[2]);

                if (row < 0 || col < 0
                            ||
                    row >= jaggedArrayRows || col >= jaggedArr[row].Length)
                {
                    continue;
                }

                if (command == "Find")
                {
                    //You have to go to the given place if it is valid and collect the token, if there is one. 
                    //When you collect it, you have to mark the place as an empty, using dash symbol.

                    if (jaggedArr[row][col] == 'T')
                    {
                        collectedTokens++;
                    }

                    jaggedArr[row][col] = '-';
                }
                else if (command == "Opponent")
                {
                    //o	One of your opponents is searching for a token at the given coordinates if they exist. 
                    //o	After going at the given coordinates (if they exist) and collecting the token (if there is such),
                    //the opponent is beginning a movement in the given direction by 3 steps.
                    //He collects all the tokens that are placed on his way.
                    //o	If opponent's movement is going to step outside of the field,
                    //he is stepping only on the possible indexes.
                    //o	When he finds tokens, he marks the cells as empty.
                    //o	There are four possible directions, in which he can go: "up", "down", "left", "right".

                    string direction = inputArgs[3];
                    if (jaggedArr[row][col] == 'T')
                    {
                        opponentTokens++;
                    }
                    jaggedArr[row][col] = '-';

                    if (direction == "up")
                    {
                        for (int i = 0; i < opponentStepsInDirection; i++)
                        {
                            row--;

                            if (row >= 0)
                            {
                                CheckForToken(jaggedArr, row, col);
                            }
                            else
                            {
                                row++;
                            }
                        }
                    }
                    else if (direction == "down")
                    {
                        for (int i = 0; i < opponentStepsInDirection; i++)
                        {
                            row++;

                            if (row < jaggedArrayRows)
                            {
                                CheckForToken(jaggedArr, row, col);
                            }
                            else
                            {
                                row--;
                            }
                        }
                    }
                    else if (direction == "left")
                    {
                        for (int i = 0; i < opponentStepsInDirection; i++)
                        {
                            col--;

                            if (col >= 0)
                            {
                                CheckForToken(jaggedArr, row, col);
                            }
                            else
                            {
                                col++;
                            }
                        }
                    }
                    else if (direction == "right")
                    {
                        for (int i = 0; i < opponentStepsInDirection; i++)
                        {
                            col++;

                            if (col < jaggedArr[row].Length)
                            {
                                CheckForToken(jaggedArr, row, col);
                            }
                            else
                            {
                                col--;
                            }
                        }
                    }
                }
            }

            PrintOutput(jaggedArr);
        }

        static void PrintOutput(char[][] jaggedArr)
        {
            for (int row = 0; row < jaggedArr.GetLength(0); row++)
            {
                Console.WriteLine(string.Join(" ", jaggedArr[row]));
            }

            Console.WriteLine($"Collected tokens: {collectedTokens}");
            Console.WriteLine($"Opponent's tokens: {opponentTokens}");
        }

        static void CheckForToken(char[][] jaggedArr, int row, int col)
        {
            if (jaggedArr[row][col] == 'T')
            {
                opponentTokens++;
            }

            jaggedArr[row][col] = '-';
        }

        static void JaggedArrayFill(char[][] jaggedArr)
        {
            for (int row = 0; row < jaggedArr.GetLength(0); row++)
            {
                char[] jaggedArrContent = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                jaggedArr[row] = new char[jaggedArrContent.Length];

                for (int col = 0; col < jaggedArr[row].Length; col++)
                {
                    jaggedArr[row][col] = jaggedArrContent[col];
                }
            }
        }
    }
}
