using System;
using System.Collections.Generic;

namespace P._07_HotPatato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(' ');

            int everyNth = int.Parse(Console.ReadLine());

            Queue<string> kids = new Queue<string>(input);

            while (kids.Count != 1)
            {
                for (int i = 0; i < everyNth - 1; i++)
                {
                    string potatoKid = kids.Dequeue(); //премахваме детето
                    kids.Enqueue(potatoKid); //добавяме го в края на опашката
                }
                //след като приключи цикъла премахваме детето, което е накрая на опашката
                string kidToLeave = kids.Dequeue();
                Console.WriteLine($"Removed {kidToLeave}");
            }
            Console.WriteLine($"Last is {kids.Peek()}");
        }
    }
}
