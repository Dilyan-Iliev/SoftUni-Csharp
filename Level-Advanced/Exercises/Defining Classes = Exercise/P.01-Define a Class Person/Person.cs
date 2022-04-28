using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Person
    {
        //Constructors
        public Person()
        {

        }
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age; 
        }

        //Fields
        private string name;
        private int age;

        //Properties
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public int Age
        {
            get { return this.age; }
            set { this.age = value; }
        }
    }
}
