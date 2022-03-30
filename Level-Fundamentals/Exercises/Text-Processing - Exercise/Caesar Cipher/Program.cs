using System;
using System.Text;

namespace Caesar_Cipher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var sb = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                char currentLetter = input[i];
                currentLetter += (char)3; //currentLetter става currentLetter + 3, т.е. измества се с 3 букви напред
                sb.Append(currentLetter);
            }
            Console.WriteLine(sb);
        }
    }
}
