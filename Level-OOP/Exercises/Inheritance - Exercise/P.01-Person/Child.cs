using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    public class Child : Person
    {
        public Child(int age, string name) : base(age, name)
        {
            this.Age = age;
            this.Name = name;
        }
    }
}
