using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BakeryOpenning
{
    public class Bakery
    {
        private List<Employee> employees;

        public Bakery(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            employees = new List<Employee>();
        }

        public string Name { get; private set; }
        public int Capacity { get; private set; }
        public IReadOnlyCollection<Employee> Employees => employees.AsReadOnly();
        public int Count => employees.Count;

        public void Add(Employee employee)
        {
            if (Capacity > employees.Count)
            {
                employees.Add(employee);
            }
        }

        public bool Remove(string name)
        {
            Employee employee = employees
                .Where(x => x.Name == name)
                .FirstOrDefault();

            if (employee != null)
            {
                employees.Remove(employee);
                return true;
            }

            return false;
        }

        public Employee GetOldestEmployee() => employees
            .OrderByDescending(x => x.Age)
            .FirstOrDefault();

        public Employee GetEmployee(string name) => employees
            .Where(x => x.Name == name)
            .FirstOrDefault();

        public string Report()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Employees working at Bakery {Name}:");

            foreach (var employee in employees)
            {
                sb.AppendLine(employee.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
