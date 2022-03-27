using System;

namespace Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int num = 1; num <= n; num++)
            {
                int sum = 0;
                int currentDigit = num;

                while (currentDigit>0)
                {
                    sum += currentDigit % 10;
                    currentDigit = currentDigit / 10;
                }
                if (sum==5||
                    sum==7||
                    sum==11)
                {
                    Console.WriteLine($"{num} -> True");
                }
                else
                {
                    Console.WriteLine($"{num} -> False");
                }

            }
        }
    }
}
