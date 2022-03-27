using System;

namespace Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double total = 0;

            for (int i = 1; i <= n; i++)
            {
                double current = 0;

                double pricePerCapsule = double.Parse(Console.ReadLine());
                int days = int.Parse(Console.ReadLine());
                int capsulesCount = int.Parse(Console.ReadLine());

                current = ((days * capsulesCount) * pricePerCapsule);
                Console.WriteLine($"The price for the coffee is: ${current:F2}");
                total += current;
            }
            Console.WriteLine($"Total: ${total:F2}");
        }
    }
}
