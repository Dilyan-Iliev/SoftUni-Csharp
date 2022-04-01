using System;
using System.Text;

namespace Secret_Chat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string command;
            while ((command = Console.ReadLine()) != "Reveal")
            {
                string[] cmdArgs = command
                    .Split(":|:", StringSplitOptions.RemoveEmptyEntries);

                StringManipulation(ref input, cmdArgs);
            }
            Console.WriteLine($"You have a new text message: {input}");
        }

        static string StringManipulation(ref string input, string[] arr)
        {
            string command = arr[0];

            switch (command)
            {
                case "InsertSpace": InsertSpaceCmd(ref input, arr); break;
                case "Reverse": ReverseCmd(ref input, arr); break;
                case "ChangeAll": ChangeAllCmd(ref input, arr); break;
            }
            return input;
        }

        static string InsertSpaceCmd(ref string input, string[] arr)
        {
            int index = int.Parse(arr[1]);
            string stringToInsert = " ";

            input = input.Insert(index, stringToInsert);

            Console.WriteLine(input);
            return input;
        }

        static string ReverseCmd(ref string input, string[] arr)
        {
            string substring = arr[1];

            if (input.Contains(substring))
            {
                var sb = new StringBuilder();

                int index = input.IndexOf(substring);
                //string partToCut = input.Substring(index, substring.Length);
                input = input.Remove(index, substring.Length);

                for (int i = substring.Length - 1; i >= 0; i--)
                {
                    sb.Append(substring[i]);
                }
                input = input.Insert(input.Length, sb.ToString());
                Console.WriteLine(input);
            }
            else
            {
                Console.WriteLine("error");
            }

            return input;
        }

        static string ChangeAllCmd(ref string input, string[] arr)
        {
            string wordToReplace = arr[1];
            string wordToReplaceWith = arr[2];

            input = input.Replace(wordToReplace, wordToReplaceWith);

            Console.WriteLine(input);
            return input;
        }
    }
}
