using System;
using System.Collections.Generic;
using System.Linq;

namespace P._02_Sets_of_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ',StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            //On the first line, you will receive two numbers 

            int firstNumber = numbers[0];
            int secondNumber = numbers[1];  

            HashSet<int> nSet = new HashSet<int>();
            HashSet<int> mSet = new HashSet<int>();

            int number;

            for (int i = 0; i < firstNumber; i++)
            {
                number = int.Parse(Console.ReadLine());
                
                nSet.Add(number);
            }

            for (int i = 0; i < secondNumber; i++)
            {
                number = int.Parse(Console.ReadLine());

                mSet.Add(number);
            }

            nSet.IntersectWith(mSet); //метод, който модифицира даден HashSet да съдържа само тези елементи,
            //които се съдържат в друг HashSet 
            //or only Intersect

            Console.WriteLine(string.Join(' ', nSet));
        }
    }
}
