using System;
using System.Linq;
using System.Collections.Generic;

namespace P._09_Simple_Text_Editor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<string> stack = new Stack<string>();

            int n = int.Parse(Console.ReadLine());

            string text = string.Empty;

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string currentCmd = command[0];

                if (currentCmd == "1")
                {
                    stack.Push(text);
                    string textToAdd = command[1];
                    text += textToAdd;
                }
                else if (currentCmd == "2")
                {
                    int numberOfElementsToErase = int.Parse(command[1]);
                    stack.Push(text);

                    for (int j = 0; j < numberOfElementsToErase; j++)
                    {
                        text = text.Remove(text.Length - 1);
                    }

                }
                else if (currentCmd == "3")
                {
                    int elementToPrint = int.Parse(command[1]);

                    Console.WriteLine(text[elementToPrint - 1]);
                }
                else if (currentCmd == "4")
                {
                    text = stack.Pop();
                }
            }
        }
    }
}
