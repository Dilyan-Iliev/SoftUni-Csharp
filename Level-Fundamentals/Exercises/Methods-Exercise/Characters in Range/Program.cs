using System;

namespace Characters_in_Range
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char start = char.Parse(Console.ReadLine());
            char end = char.Parse(Console.ReadLine());
            PrintCharsInRange(start, end);
        }

        static void PrintCharsInRange(char symbolForStart, char symbolForEnd)
        {
            int startCharacter = Math.Min(symbolForStart, symbolForEnd); //проверявам кое е с по-малка стойност в ASCII таблицата и започвам цикъла от него +1
            int endCharacter = Math.Max(symbolForStart, symbolForEnd);//проверявам кое е с по-голяма стойност в ASCII таблицата и приключвам цикъла до него

            for (int i = startCharacter + 1; i < endCharacter; i++)
            {
                Console.Write((char)i + " ");
            }

            //if (symbolForEnd < symbolForStart) като горното, но по-подробно,
            //{
            //    for (int i = symbolForEnd + 1; i < symbolForStart; i++)
            //    {
            //        Console.Write((char)i + " ");
            //    }
            //}
            //else
            //{
            //    for (int i = symbolForStart + 1; i < symbolForEnd; i++)
            //    {
            //        Console.Write((char)i + " ");
            //    }
            //}
        }
    }
}
