using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Match_Phone_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string numbers = Console.ReadLine();
            string pattern = @"\+359( |-)2\1\d{3}\1\d{4}\b";

            string[] matches = Regex.Matches(numbers, pattern)
                .Select(x => x.Value)
                .ToArray();
            Console.WriteLine(string.Join(", ", matches));

            //or

            //string numbers = Console.ReadLine();
            //string pattern = @"\+359( |-)2\1\d{3}\1\d{4}\b";
            //var regex = new Regex(pattern);

            //MatchCollection matches = regex.Matches(numbers);

            //List<string> result = new List<string>();
            //foreach (Match item in matches)
            //{
            //    result.Add(item.Value);
            //}
            //Console.WriteLine(string.Join(", ", result));
        }
    }
}
