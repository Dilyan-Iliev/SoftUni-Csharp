using System;
using System.Collections.Generic;
using System.Linq;

namespace Students
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var studentsList = new List<Student>();

            string input = Console.ReadLine();
            while (input!= "end") //Read a list of students until you receive the "end" command
            {
                string[] currentStudentData = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string firstName = currentStudentData[0]; //or currentStudent.FirstName = currentStudentData[0];
                string lastName = currentStudentData[1];//or currentStudent.LasttName = currentStudentData[1];
                int age = int.Parse(currentStudentData[2]);//or currentStudent.Age = currentStudentData[2];
                string homeTown = currentStudentData[3];//or currentStudent.Home = currentStudentData[3];

                Student currentStudent = new Student();
                currentStudent.FirstName = firstName;
                currentStudent.LastName = lastName;
                currentStudent.Age = age;
                currentStudent.HomeTown = homeTown;

                studentsList.Add(currentStudent);
                input = Console.ReadLine();
            }

            string cityName = Console.ReadLine(); //After that, you will receive a name of a city.

            //List<Student> filteredStudents = studentsList.Where(x => x.HomeTown.Equals (cityName)).ToList();
            //foreach (var student in filteredStudents)
            //{
            //    Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
            //}

            foreach (var student in studentsList)
            {
                if (student.HomeTown == cityName)
                {
                    Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
                }
            }
        }
    }

    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string HomeTown { get; set; }
    }
}
