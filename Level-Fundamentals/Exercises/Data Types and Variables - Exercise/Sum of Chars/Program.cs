using System;

namespace Sum_of_Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            //int n = int.Parse(Console.ReadLine());
            //int sum = 0;
            //for (int i = 1; i <= n; i++)
            //{
            //    string word = Console.ReadLine(); //декларираме string, за да може да използваме подадената буква, която винаги ще е на 0 позиция
            //    int ascii = word[0];
            //    sum += ascii;

            //}
            //Console.WriteLine($"The sum equals: {sum}") ;

            int itterations = int.Parse(Console.ReadLine());
            int sum = 0;

            for (int i = 1; i <= itterations; i++)
            {
                char currentSymbol = char.Parse(Console.ReadLine());
                sum += (char)currentSymbol;
            }
            Console.WriteLine($"The sum equals: {sum}");
        }
    }
}
