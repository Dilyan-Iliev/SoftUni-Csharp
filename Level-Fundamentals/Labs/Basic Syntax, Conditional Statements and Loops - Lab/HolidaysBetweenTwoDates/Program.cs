using System;
using System.Globalization;

namespace HolidaysBetweenTwoDates
{
    class Program
    {
        static void Main(string[] args)
        {
            var startDate = DateTime.ParseExact(Console.ReadLine(),
            "d.M.yyyy", CultureInfo.InvariantCulture); // it was dd.m.yyyy
            var endDate = DateTime.ParseExact(Console.ReadLine(),
                "d.M.yyyy", CultureInfo.InvariantCulture); // it was dd.m.yyyy
            var holidaysCount = 0;
            for (var date = startDate; date <= endDate; date = date.AddDays(1)) //трябваше скобите да се оправят
            {
                if (date.DayOfWeek == DayOfWeek.Saturday || //трябваше да се промени операторът на ИЛИ вместо И
                    date.DayOfWeek == DayOfWeek.Sunday) 
                {
                    holidaysCount++;
                }
            }
                    Console.WriteLine(holidaysCount);
        }
    }
}
