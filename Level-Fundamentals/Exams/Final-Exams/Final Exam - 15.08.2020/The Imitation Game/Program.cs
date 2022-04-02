using System;

namespace The_Imitation_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();
            string command;
            while ((command = Console.ReadLine()) != "Decode")
            {
                string[] cmdArgs = command
                    .Split('|', StringSplitOptions.RemoveEmptyEntries);
                string currentCmd = cmdArgs[0];

                switch (currentCmd)
                {
                    case "Move": MoveCmd(ref message, cmdArgs); break;
                    case "Insert": InsertCmd(ref message, cmdArgs); break;
                    case "ChangeAll": ChangeAllCmd(ref message, cmdArgs); break;
                }
            }
            Console.WriteLine($"The decrypted message is: {message}");
        }

        static string MoveCmd(ref string message, string[] arr)
        {
            int lettersToMove = int.Parse(arr[1]);
            string substring = message.Substring(0, lettersToMove);
            message = message.Remove(0, lettersToMove); 
            message = message.Insert(message.Length, substring);

            return message;
        }

        static string InsertCmd(ref string message, string[] arr)
        {
            int index = int.Parse(arr[1]);
            string wordToInsert = arr[2];

            message = message.Insert(index, wordToInsert);

            return message;
        }

        static string ChangeAllCmd(ref string message, string[] arr)
        {
            string wordToReplace = arr[1];
            string wordToReplaceWith = arr[2];

            message = message.Replace(wordToReplace, wordToReplaceWith);

            return message;
        }
    }
}
