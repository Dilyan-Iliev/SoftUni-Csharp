using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BakeryOpenning
{
    public class Bakery
    {
        public List<Employee> Employees { get; set; }
        public string Name { get; set; }    
        public int Capacity { get; set; }

        public Bakery(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.Employees = new List<Employee>();
        }
        public int Count => this.Employees.Count;
        public void Add(Employee employee)
        {
            if (Employees.Count < this.Capacity)
            {
                Employees.Add(employee);
            }
        }
        public bool Remove(string name)
        {
            Employee employee = Employees.Where(x => x.Name == name).FirstOrDefault();

            if (employee != null)
            {
                Employees.Remove(employee);
                return true;
            }

            return false;
        }
        public Employee GetOldestEmployee()
        {
            return Employees.OrderByDescending(x => x.Age).First();
        }
        public Employee GetEmployee(string name)
        {
            return Employees.Where(x => x.Name == name).FirstOrDefault();
        }
        public string Report()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Employees working at Bakery {Name}:");

            foreach (var item in Employees)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
