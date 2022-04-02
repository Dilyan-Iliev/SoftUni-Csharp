using System;
using System.Collections.Generic;

namespace The_Pianist
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dictionary = new Dictionary<string, Piece>();
            int numberOfPieces = int.Parse(Console.ReadLine());

            for (int i = 1; i <= numberOfPieces; i++)
            {
                string[] pieceData = Console.ReadLine()
                    .Split('|', StringSplitOptions.RemoveEmptyEntries);
                string pieceName = pieceData[0];
                string pieceComposer = pieceData[1];
                string pieceKey = pieceData[2];

                if (!dictionary.ContainsKey(pieceName))
                {
                    var piece = new Piece(pieceComposer, pieceKey);
                    dictionary[pieceName] = piece;
                }
            }

            string command;
            while ((command = Console.ReadLine()) != "Stop")
            {
                string[] cmdArgs = command
                    .Split('|', StringSplitOptions.RemoveEmptyEntries);

                string currentCmd = cmdArgs[0];
                switch (currentCmd)
                {
                    case "Add": AddCmd(dictionary, cmdArgs); break;
                    case "Remove": RemoveCmd(dictionary, cmdArgs); break;
                    case "ChangeKey": ChangeKeyCmd(dictionary, cmdArgs); break;
                }
            }
            PrintDictionary(dictionary);
        }

        static Dictionary<string, Piece> AddCmd(Dictionary<string, Piece> dict, string[] arr)
        {
            string pieceToAdd = arr[1];
            string composer = arr[2];
            string key= arr[3];

            if (dict.ContainsKey(pieceToAdd))
            {
                Console.WriteLine($"{pieceToAdd} is already in the collection!");
            }
            else
            {
                var piece = new Piece(composer, key);
                dict[pieceToAdd] = piece;
                Console.WriteLine($"{pieceToAdd} by {composer} in {key} added to the collection!");
            }

            return dict;
        }

        static Dictionary<string, Piece> RemoveCmd(Dictionary<string, Piece> dict, string[] arr)
        {
            string pieceToRemove = arr[1];

            if (!dict.ContainsKey(pieceToRemove))
            {
                Console.WriteLine($"Invalid operation! {pieceToRemove} does not exist in the collection.");
            }
            else
            {
                Console.WriteLine($"Successfully removed {pieceToRemove}!");
                dict.Remove(pieceToRemove);
            }

            return dict;
        }

        static Dictionary<string, Piece> ChangeKeyCmd(Dictionary<string, Piece> dict, string[] arr)
        {
            string piece = arr[1];
            string newKey = arr[2];

            if (!dict.ContainsKey(piece))
            {
                Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
            }
            else
            {
                dict[piece].PieceKey = newKey;
                Console.WriteLine($"Changed the key of {piece} to {newKey}!");
            }
            return dict;
        }

        static void PrintDictionary(Dictionary<string, Piece> dict)
        {
            foreach (var kvp in dict)
            {
                Console.WriteLine($"{kvp.Key} -> Composer: {kvp.Value.PieceComposer}, Key: {kvp.Value.PieceKey}");
            }
        }
    }

    public class Piece
    {
        public Piece(string composer, string key)
        {
            this.PieceComposer = composer;
            this.PieceKey = key;
        }
        public string PieceComposer { get; set; }
        public string PieceKey { get; set; }

    }
}
