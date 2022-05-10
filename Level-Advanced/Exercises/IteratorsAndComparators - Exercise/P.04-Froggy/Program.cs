using System;
using System.Linq;

namespace P._04_Froggy
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] stones = Console.ReadLine()
                .Split(", ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var lake = new Lake(stones);
            Console.WriteLine(string.Join(", ", lake));
        }
    }
}
