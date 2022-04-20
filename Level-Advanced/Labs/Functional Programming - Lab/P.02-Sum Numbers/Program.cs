using System;
using System.Linq;

namespace P._02_Sum_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Func<string, int> parser = Parser(input);
            // or Instead of writing the method we can do = x => int.Parse(x) 

            int[] numbers = input.Split(", ",
                       StringSplitOptions.RemoveEmptyEntries)
                       .Select(parser).ToArray(); //here i can pass MyParse in the Select

            Console.WriteLine(numbers.Count());
            Console.WriteLine(numbers.Sum());
        }

        static Func<string, int> Parser(string input) //правя си метод/функция, която получава string и връща парснат инт
        {
            return x => int.Parse(x);
        }
        
        //static int MyParse(string input)
        //{
        //    //how parse works

        //    int number = 0;
        //    foreach (var symbol in input)
        //    {
        //        number *= 10;
        //        number += (symbol - '0');
        //    }
        //    return number;
        //}
    }
}
