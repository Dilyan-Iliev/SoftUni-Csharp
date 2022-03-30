using System;
using System.Collections.Generic;
using System.Linq;

namespace Students2._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var studentsList = new List<Student>();

            string input = Console.ReadLine();
            while (input != "end") //Read a list of students until you receive the "end" command
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

                if (currentStudent.IsStudentExists(studentsList, currentStudent.FirstName, currentStudent.LastName))
                {
                    Student student = currentStudent.GetStudent(studentsList, currentStudent.FirstName, currentStudent.LastName);

                    student.FirstName = firstName;
                    student.LastName = lastName;
                    student.Age = age;
                    student.HomeTown = homeTown;
                }
                else
                {
                    Student student = new Student()
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        Age = age,
                        HomeTown = homeTown,
                    };
                    studentsList.Add(student);
                }
                input = Console.ReadLine();
            }

            string cityName = Console.ReadLine();
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

        public bool IsStudentExists(List<Student> list, string firstName, string lastName)
        {
            foreach (var student in list)
            {
                if (student.FirstName == firstName && student.LastName == lastName)
                {
                    return true;
                }
            }
            return false;
        }

        public Student GetStudent(List<Student> list, string firstName, string lastName)
        {
            Student existingStudent = null;

            foreach (var student in list)
            {
                if (student.FirstName == firstName && student.LastName == lastName)
                {
                    existingStudent = student;
                }
            }
            return existingStudent;
        }

    }
}
