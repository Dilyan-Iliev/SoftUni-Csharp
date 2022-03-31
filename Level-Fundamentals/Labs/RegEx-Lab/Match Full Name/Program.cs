using System;
using System.Text.RegularExpressions;

namespace Match_Full_Name
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string names = Console.ReadLine();

            Regex regex = new Regex(@"\b[A-Z][a-z]+ [A-Z][a-z]+\b");
            
            MatchCollection matches = regex.Matches(names);

            foreach (Match match in matches)
            {
                Console.Write($"{match.Groups[0].Value} ");
            }
        }
    }
}
