using System;

namespace SoftUni_Reception
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstEmployeeEfficiency = int.Parse(Console.ReadLine());
            int secondEmployeeEfficiency = int.Parse(Console.ReadLine());
            int thirdEmployeeEfficiency = int.Parse(Console.ReadLine());
            int studentsCount = int.Parse(Console.ReadLine());

            int studentsForHour = firstEmployeeEfficiency + secondEmployeeEfficiency+ thirdEmployeeEfficiency;
            

            int hoursCounter = 0; //Every fourth hour, all employees have a break, so they don't work for an hour

            while (studentsCount > 0)
            {
                hoursCounter++;
                if (hoursCounter % 4 == 0)
                {
                    continue;
                }
                studentsCount -= studentsForHour;
            }
            Console.WriteLine($"Time needed: {hoursCounter}h.");
        }
    }
}
