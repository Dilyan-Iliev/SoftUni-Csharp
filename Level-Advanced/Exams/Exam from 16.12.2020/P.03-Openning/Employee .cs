using System;
using System.Collections.Generic;
using System.Text;

namespace BakeryOpenning
{
    public class Employee
    {
        public Employee(string name, int age, string country)
        {
            Name = name;
            Age = age;
            Country = country;
        }

        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Country { get; private set; }

        public override string ToString()
        {
            return $"Employee: {Name}, {Age} ({Country})";
        }
    }
}
