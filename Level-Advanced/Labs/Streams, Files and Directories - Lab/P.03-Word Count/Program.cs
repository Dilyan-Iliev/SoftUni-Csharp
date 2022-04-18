using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace P._03_Word_Count
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string wordsPath = @"C:\Users\IvonaVelkova\source\repos\Advanced\Advanced - course\Streams, Files and Directories - Lab\P.03-Word Count\words List.txt";
            string textPath = @"C:\Users\IvonaVelkova\source\repos\Advanced\Advanced - course\Streams, Files and Directories - Lab\P.03-Word Count\text File.txt";
            string outputPath = @"C:\Users\IvonaVelkova\source\repos\Advanced\Advanced - course\Streams, Files and Directories - Lab\P.03-Word Count\output text.txt";

            var matchedWords = new Dictionary<string, int>();

            string wordsReader = File.ReadAllText(wordsPath);
            string[] wordsArr = wordsReader
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            using StreamWriter textWriter = new StreamWriter(outputPath);
            using StreamReader textReader = new StreamReader(textPath);

            CheckForWords(matchedWords, wordsArr, textReader);

            PrintOutPut(matchedWords, textWriter);
        }

        private static void PrintOutPut(Dictionary<string, int> matchedWords, StreamWriter textWriter)
        {
            foreach (var kvp in matchedWords
                .OrderByDescending(x => x.Value))
            {
                textWriter.WriteLine($"{kvp.Key} - {kvp.Value}");
            }
        }

        private static void CheckForWords(Dictionary<string, int> matchedWords, string[] wordsArr, StreamReader textReader)
        {
            while (!textReader.EndOfStream)
            {
                string line = textReader.ReadLine().ToLower();

                foreach (var word in wordsArr)
                {
                    if (line.Contains(word))
                    {
                        if (!matchedWords.ContainsKey(word))
                        {
                            matchedWords.Add(word, 0);
                        }
                        matchedWords[word]++;
                    }
                }
            }
        }
    }
}
