using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        private List<Student> students;

        public Classroom(int capacity)
        {
            Capacity = capacity;
            students = new List<Student>();
        }
        public int Capacity { get; private set; }
        public IReadOnlyList<Student> Students => students;
        public int Count => students.Count;

        public string RegisterStudent(Student student)
        {
            if (Capacity > students.Count)
            {
                students.Add(student);

                return $"Added student {student.FirstName} {student.LastName}";
            }

            return "No seats in the classroom";
        }

        public string DismissStudent(string firstName, string lastName)
        {
            Student student = students.Where(x => x.FirstName == firstName && x.LastName == lastName)
                .FirstOrDefault();

            if (student != null)
            {
                students.Remove(student);

                return $"Dismissed student {student.FirstName} {student.LastName}";
            }

            return "Student not found";
        }

        public string GetSubjectInfo(string subject)
        {
            var filteredStudents = students.Where(x => x.Subject == subject).ToList();

            if (filteredStudents.Any())
            {
                var sb = new StringBuilder();

                sb.AppendLine($"Subject: {subject}");
                sb.AppendLine("Students:");
                foreach (var student in filteredStudents)
                {
                    sb.AppendLine($"{student.FirstName} {student.LastName}");
                }

                return sb.ToString().TrimEnd();
            }

            return "No students enrolled for the subject";
        }

        public int GetStudentsCount() => this.Count;

        public Student GetStudent(string firstName, string lastName) => students
            .Where(x => x.FirstName == firstName && x.LastName == lastName)
            .FirstOrDefault();
    }
}
