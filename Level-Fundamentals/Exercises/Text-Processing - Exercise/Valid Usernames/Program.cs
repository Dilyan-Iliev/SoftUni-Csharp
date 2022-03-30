using System;
using System.Collections.Generic;

namespace Valid_Usernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] userNames = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            var validUserNames = new List<string>();
            //Has length between 3 and 16 characters
            //Contains only letters, numbers, hyphens and underscores
            //Has no redundant symbols before, after or in between

            foreach (var userName in userNames)
            {
                if (userName.Length >= 3 && userName.Length <= 16)
                {
                    var check = CheckForSymbols(userName);

                    if (check)
                    {
                        validUserNames.Add(userName);
                    }
                }
            }
            Console.WriteLine(string.Join(Environment.NewLine, validUserNames));
        }

        private static bool CheckForSymbols(string userName)
        {
            foreach (var letter in userName)
            {

                if (! (char.IsLetterOrDigit(letter)
                    || letter == '-'
                    || letter == '_') )
                {
                    return false;
                }
                else
                {
                    continue;
                }
            }
            return true;
        }
    }
}
