using System;
using System.Text.RegularExpressions;

namespace Extract_Emails
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string emailPattern = @"(^|(?<=\s))(([a-zA-Z0-9]+)([\.\-_]?)([A-Za-z0-9]+)(@)([a-zA-Z]+([\.\-_][A-Za-z]+)+))(\b|(?=\s))";

            Regex regex = new Regex(emailPattern);

            MatchCollection matches = regex.Matches(input);

            foreach (Match match in matches)
            {
                if (match.Success)
                {
                    Console.WriteLine(match.Value);
                }
            }
        }
    }
}
