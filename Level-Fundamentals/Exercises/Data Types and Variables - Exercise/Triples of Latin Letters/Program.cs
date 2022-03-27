using System;

namespace Triples_of_Latin_Letters
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (char i = 'a'; i < 'a' + n; i++)
            {
                for (char k = 'a'; k <'a'+n; k++)
                {
                    for (char l ='a'; l <'a'+n; l++)
                    {
                        Console.WriteLine($"{i}{k}{l}");
                    }
                }
            }
        }
    }
}
