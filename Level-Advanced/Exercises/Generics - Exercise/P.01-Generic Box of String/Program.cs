using System;
using System.Collections.Generic;

namespace P._01_Generic_Box_of_String
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Box<string> box = new Box<string>();
                box.BoxElement = Console.ReadLine();
                Console.WriteLine(box.ToString());
            }
        }
    }
}
