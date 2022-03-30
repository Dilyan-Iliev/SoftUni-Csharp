using System;
using System.Collections.Generic;
using System.Linq;

namespace Students
{
    internal class Program
    {
        static void Main(string[] args)
        {
            byte numberOfStudents = byte.Parse(Console.ReadLine());
            List<Student> students = new List<Student>();

            for (int i = 1; i <= numberOfStudents; i++)
            {
                string[] arr = Console.ReadLine()
                    .Split()
                    .ToArray();

                string firstName = arr[0];
                string lastName = arr[1];
                double grade = double.Parse(arr[2]);

                var student = new Student(firstName, lastName, grade);
                students.Add(student);
            }
            var orderedStudents = students.OrderByDescending(student => student.Grade).ToList();
            // or var orderedStudents = students.OrderBy(student => student.Grade).ToList();
            //orderedStudents.Reverse();
            Console.WriteLine(string.Join(Environment.NewLine, orderedStudents));
        }
    }

    class Student
    {
        public Student(string firstName, string lastName, double grade)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Grade = grade;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Grade { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}: {Grade:F2}";
        }
    }
}
