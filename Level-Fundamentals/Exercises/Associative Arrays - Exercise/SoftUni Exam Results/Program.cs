using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUni_Exam_Results
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var resultDictionary = new Dictionary<string, int>();
            var submissionsDictionary = new Dictionary<string, int>();

            int max = int.MinValue;

            string input;
            while ((input = Console.ReadLine()) != "exam finished")
            {
                string[] inputArgs = input.Split('-', StringSplitOptions.RemoveEmptyEntries);
                string user = inputArgs[0];
                string cmd = inputArgs[1];
                
                if (inputArgs[1] != "banned")
                {
                    int points = int.Parse(inputArgs[2]);

                    if (!resultDictionary.ContainsKey(user))
                    {
                        resultDictionary[user] = points;
                        max = points;
                    }
                    else // if (resultDictionary.ContainsKey(user))
                    {
                        if (points > max) 
                        {
                            max = points;
                            resultDictionary[user] = max;
                        }
                    }

                    if (!submissionsDictionary.ContainsKey(cmd))
                    {
                        submissionsDictionary[cmd]=1;
                    }
                    else
                    {
                        submissionsDictionary[cmd]++;
                    }
                }
                else // if cmd == "banned
                {
                    resultDictionary.Remove(user);
                }
            }

            PrintDictionary(resultDictionary, submissionsDictionary);
        }

        static void PrintDictionary (Dictionary<string, int> resultDictionary, 
            Dictionary <string, int> submissionDictionary)
        {
            Console.WriteLine("Results:");
            foreach (var kvp in resultDictionary.OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key))
            {
                Console.WriteLine($"{kvp.Key} | {kvp.Value}");
            }

            Console.WriteLine("Submissions:");
            foreach (var kvp in submissionDictionary.OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key))
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value}");
            }
        }
    }
}
