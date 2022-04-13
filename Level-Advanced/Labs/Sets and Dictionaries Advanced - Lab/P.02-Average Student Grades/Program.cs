using System;
using System.Linq;
using System.Collections.Generic;

namespace P._02_Average_Student_Grades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfStudents = int.Parse(Console.ReadLine());

            Dictionary<string, List<decimal>> studentGrades = new Dictionary<string, List<decimal>>();

            for (int student = 1; student <= numberOfStudents; student++)
            {
                string[] info = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string studentName = info[0];
                decimal studentGrade = decimal.Parse(info[1]);

                if (!studentGrades.ContainsKey(studentName))
                {
                    studentGrades.Add(studentName, new List<decimal>());
                    studentGrades[studentName].Add(studentGrade);
                }
                else
                {
                    studentGrades[studentName].Add(studentGrade);
                }
            }

            foreach (var kvp in studentGrades)
            {
                string student = kvp.Key;
                List<decimal> grades = kvp.Value;
                decimal average = grades.Average();

                Console.Write($"{student} -> ");
                foreach (var grade in grades)
                {
                    Console.Write($"{grade:f2} ");
                }
                Console.WriteLine($"(avg: {average:f2})");

                //Console.WriteLine($"{student} -> {string.Join(" ", grades)} (avg: {average:f2})");
            }
        }
    }
}
