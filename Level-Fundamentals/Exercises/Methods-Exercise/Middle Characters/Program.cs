using System;

namespace Middle_Characters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            PrintMiddleCharacters(input);
        }

        static void PrintMiddleCharacters(string input)
        {
            if (input.Length % 2 == 0)
            {
                Console.WriteLine($"{input[input.Length / 2 - 1]}{input[input.Length / 2]}"); //напр. числото 1234 -> чрез /2 разделям четен стринг на 2 и взимам позицията минус1
               // Console.WriteLine(input[input.Length / 2]);
            }
            else
            {
                Console.WriteLine(input[input.Length / 2]); //123 -> 3/2 = 1 и ми връща индекс на 1ва позиция, т.е. 2ката
            }
        }
    }
}
