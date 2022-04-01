using System;

namespace WorldTour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string command;
            while ((command = Console.ReadLine()) != "Travel")
            {
                string[] cmdArgs = command
                    .Split(':', StringSplitOptions.RemoveEmptyEntries);

                string currentCmd = cmdArgs[0];

                switch (currentCmd)
                {
                    case "Add Stop": AddCmd(ref input, cmdArgs); break;
                    case "Remove Stop": RemoveCmd(ref input, cmdArgs); break;
                    case "Switch": SwitchCmd(ref input, cmdArgs); break;
                }
            }
            Console.WriteLine($"Ready for world tour! Planned stops: {input}");
        }

        static string AddCmd (ref string input, string[] arr)
        {
            int index = int.Parse(arr[1]);
            string wordToAdd = arr[2];

            if (index >=0 && index < input.Length)
            {
                input = input.Insert(index, wordToAdd);
            }

            Console.WriteLine(input);
            return input;
        }

        static string RemoveCmd (ref string input, string[] arr)
        {
            int startIndex = int.Parse(arr[1]);
            int endIndex = int.Parse(arr[2]);   

            if (startIndex >= 0 && endIndex < input.Length)
            {
                input = input.Remove(startIndex, endIndex - startIndex + 1);
            }

            Console.WriteLine(input);
            return input;
        }

        static string SwitchCmd (ref string input, string[] arr)
        {
            string oldString = arr[1];
            string newString = arr[2];

            if (input.Contains(oldString))
            {
                input = input.Replace(oldString, newString);
            }
            Console.WriteLine(input);
            return input;
        }
    }
}
