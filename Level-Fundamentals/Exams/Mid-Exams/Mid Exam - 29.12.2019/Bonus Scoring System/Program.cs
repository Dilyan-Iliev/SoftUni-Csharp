using System;

namespace Bonus_Scoring_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int students = int.Parse(Console.ReadLine());
            int numberOfLectures = int.Parse(Console.ReadLine());
            int bonus = int.Parse(Console.ReadLine());
            double biggestBonus = 0;
            int maxAttendance = 0;
           

            //{total bonus} = {student attendances} / {course lectures} * (5 + {additional bonus})

            for (int i = 0; i < students; i++)
            {
                int singleStudentAttendance = int.Parse(Console.ReadLine());
                double totalBonus = ((1.0 * singleStudentAttendance / numberOfLectures) * (5 + bonus));

                if (totalBonus > biggestBonus)
                {
                    biggestBonus = totalBonus;
                    maxAttendance = singleStudentAttendance;
                }
            }

            Console.WriteLine($"Max Bonus: {Math.Ceiling(biggestBonus)}.");
            Console.WriteLine($"The student has attended {maxAttendance} lectures.");
        }
    }
}
