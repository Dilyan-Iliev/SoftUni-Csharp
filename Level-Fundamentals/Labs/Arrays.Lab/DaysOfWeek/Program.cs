using System;

namespace DaysOfWeek
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            string[] days = {"Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday",
            "Sunday"};

            if (number >= 1 && number <= 7)
            {
                Console.WriteLine(days[number - 1]);
            }
            else
            {
                Console.WriteLine("Invalid day!");
            }

            //or

            //int number = int.Parse(Console.ReadLine());

            //string[] days = {"Monday",
            //"Tuesday",
            //"Wednesday",
            //"Thursday",
            //"Friday",
            //"Saturday",
            //"Sunday"};

            //if (number == 1)
            //{
            //    Console.WriteLine(days[0]);
            //}
            //else if (number == 2)
            //{
            //    Console.WriteLine(days[1]);
            //}
            //else if (number == 3)
            //{
            //    Console.WriteLine(days[2]);
            //}
            //else if (number == 4)
            //{
            //    Console.WriteLine(days[3]);
            //}
            //else if (number == 5)
            //{
            //    Console.WriteLine(days [4]);
            //}
            //else if (number == 6)
            //{
            //    Console.WriteLine(days [5]);
            //}
            //else if (number == 7)
            //{
            //    Console.WriteLine(days[6]);
            //}
            //else
            //{
            //    Console.WriteLine("Invalid day!");
            //}
        }
    }
}
