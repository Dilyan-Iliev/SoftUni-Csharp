using System;

namespace Operations
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            MathOperations operations = new MathOperations();
            Console.WriteLine(operations.Add(3, 4));
            Console.WriteLine(operations.Add(1.5, 3.5, 5.1));
            Console.WriteLine(operations.Add(1.5m, 3.5m, 5.1m));
        }
    }
}
