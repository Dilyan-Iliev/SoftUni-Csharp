using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        public List<Student> Students { get; set; }
        public int Capacity { get; set; }

        public Classroom(int capacity)
        {
            this.Capacity = capacity;
            this.Students = new List<Student>();
        }
        public int Count => this.Students.Count;
        public string RegisterStudent(Student student)
        {
            if (Students.Count >= this.Capacity)
            {
                return "No seats in the classroom";
            }

            Students.Add(student);
            return $"Added student {student.FirstName} {student.LastName}";
        }
        public string DismissStudent(string firstName, string lastName)
        {
            Student student = Students.Where(x => x.FirstName == firstName && x.LastName == lastName).FirstOrDefault();

            if (student != null)
            {
                Students.Remove(student);
                return $"Dismissed student {firstName} {lastName}";
            }

            return "Student not found";
        }
        public string GetSubjectInfo(string subject)
        {
            var filteredStudents = Students.Where(x => x.Subject == subject).ToList();

            if (filteredStudents.Any())
            {
                var sb = new StringBuilder();
                sb.AppendLine($"Subject: {subject}");
                sb.AppendLine("Students:");

                foreach (var student in filteredStudents)
                {
                    string toAppend = $"{student.FirstName} {student.LastName}";
                    sb.AppendLine(toAppend);
                }

                return sb.ToString().TrimEnd();
            }
            return "No students enrolled for the subject";
        }
        public int GetStudentsCount()
        {
            return this.Count;
        }
        public Student GetStudent(string firstName, string lastName)
        {
            Student student = Students.Where(x => x.FirstName == firstName && x.LastName == lastName).FirstOrDefault();

            return student;
        }
    }
}
