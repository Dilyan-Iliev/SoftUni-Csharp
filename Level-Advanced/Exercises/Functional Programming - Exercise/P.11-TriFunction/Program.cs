using System;
using System.Linq;
using System.Collections.Generic;

namespace P._11_TriFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            List<string> namesWithSum = new List<string>();

            foreach (var name in names)
            {
                int nameCharsSum = 0;
                for (int i = 0; i < name.Length; i++)
                {
                    char c = name[i];
                    nameCharsSum += c;
                }
                if (nameCharsSum >= n)
                {
                    namesWithSum.Add(name);
                }
            }

            var newList = namesWithSum.FirstOrDefault().ToList();
            if (newList.Any())
            {
                Console.WriteLine(string.Join("", newList));
            }
        }
    }
}
