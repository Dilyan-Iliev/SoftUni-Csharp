using System;

namespace Convert_Meters_to_Kilometers
{
    class Program
    {
        static void Main(string[] args)
        {
            int distanceMeter = int.Parse(Console.ReadLine());

            decimal distanceKM = distanceMeter / (decimal)1000; // ако е float or double Judge дава 80/100
            Console.WriteLine($"{distanceKM:f2}");
        }
    }
}
