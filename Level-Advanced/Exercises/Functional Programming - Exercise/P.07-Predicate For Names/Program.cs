using System;
using System.Linq;

namespace P._07_Predicate_For_Names
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lengthOfName = int.Parse(Console.ReadLine());
            var names = Console.ReadLine()
                .Split();

            Func<string, bool> predicate = name => name.Length <= lengthOfName;

            var filteredNames = names.Where(predicate).ToArray();

            Console.WriteLine(string.Join(Environment.NewLine, filteredNames));
        }
    }
}
