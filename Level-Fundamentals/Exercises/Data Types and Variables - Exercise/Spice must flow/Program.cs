using System;

namespace Spice_must_flow
{
    class Program
    {
        static void Main(string[] args)
        {
            int startingYield = int.Parse(Console.ReadLine());
            int days = 0;
            int yield = 0;

            while (startingYield>=100)
            {
                days++;
                yield += startingYield - 26;//The mining crew consumes 26 spices every day at the end of their shift 
                startingYield -= 10;
            }

            if (yield >= 26) //an additional 26 after the mine has been exhausted (when less than 100 spices are expected in a day, abandon the source.)
            {
                yield -= 26;
            }
            Console.WriteLine(days);
            Console.WriteLine(yield);
        }
    }
}
