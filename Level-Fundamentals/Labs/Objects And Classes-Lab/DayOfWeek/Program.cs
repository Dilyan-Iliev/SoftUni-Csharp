using System;
using System.Globalization;

namespace DayOfWeek
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputAsDate = Console.ReadLine();
            var date = DateTime.ParseExact(inputAsDate, "d-M-yyyy",
                CultureInfo.InvariantCulture);
            Console.WriteLine(date.DayOfWeek);

            // var date = DateTime.ParseExact(Console.ReadLine(), "d-M-yyyy",
            //    CultureInfo.InvariantCulture);
            //Console.WriteLine(date.DayOfWeek);
        }
    }
}
