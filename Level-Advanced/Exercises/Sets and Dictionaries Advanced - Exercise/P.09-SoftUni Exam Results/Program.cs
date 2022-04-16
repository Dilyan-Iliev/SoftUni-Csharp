using System;
using System.Linq;
using System.Collections.Generic;

namespace P._09_SoftUni_Exam_Results
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var usernameData = new Dictionary<string, Username>();
            var languageSubmissions = new Dictionary<string, int>();

            string input;
            while ((input = Console.ReadLine()) != "exam finished")
            {
                string[] inputArgs = input
                    .Split('-', StringSplitOptions.RemoveEmptyEntries);

                string username = inputArgs[0];
                string technology = inputArgs[1];

                if (technology == "banned")
                {
                    usernameData.Remove(username);
                    continue;
                }

                int points = int.Parse(inputArgs[2]);

                if (!usernameData.ContainsKey(username))
                {
                    var usernameObj = new Username(technology, points);
                    usernameData[username] = usernameObj;

                }

                if (!languageSubmissions.ContainsKey(technology))
                {
                    languageSubmissions[technology] = 1;
                }
                else
                {
                    languageSubmissions[technology]++;
                }


                if (points > usernameData[username].Points)
                {
                    usernameData[username].Points = points;
                }
            }

            PrintOutput(usernameData, languageSubmissions);
        }

        private static void PrintOutput(Dictionary<string, Username> usernameData, Dictionary<string, int> languageSubmissions)
        {
            Console.WriteLine("Results:");
            foreach (var kvp in usernameData
                .OrderByDescending(x => x.Value.Points)
                .ThenBy(x => x.Key))
            {
                Console.WriteLine($"{kvp.Key} | {kvp.Value.Points}");
            }

            Console.WriteLine("Submissions:");
            foreach (var kvp in languageSubmissions
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key))
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value}");
            }
        }
    }

    public class Username
    {
        public Username(string language, int points)
        {
            this.Language = language;
            this.Points = points;
        }
        public string Language { get; set; }
        public int Points { get; set; }

    }
}
