using System;
using System.Text;

namespace Refactoring_Prime_Checker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            int lines = int.Parse(Console.ReadLine());

            StringBuilder message = new StringBuilder();

            for (int i = 1; i <= lines; i++)
            {
                char currentLetter = char.Parse(Console.ReadLine());
                message.Append((char)(currentLetter + key));
                //message += ((char)(currentLetter + key)).ToString(); Така е без StringBuilder
            }
            Console.WriteLine(message.ToString());
        }
    }
}
