using System;

namespace P._02_Generic_Box_of_Integer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var box = new Box<int>();
                box.ElementToAdd = int.Parse(Console.ReadLine());
                Console.WriteLine(box.ToString());
            }
        }
    }
}
