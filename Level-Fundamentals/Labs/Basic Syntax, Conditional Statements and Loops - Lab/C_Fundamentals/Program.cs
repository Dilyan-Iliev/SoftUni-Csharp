using System;

namespace C_Fundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int num = 3; num <= 99; num++)
            {
                if (num % 3 == 0)
                {
                    Console.WriteLine(num);
                }
            }
        }
    }
}
