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
            this.Name = "No name";
            this.Age = 1;
        }

        public Person(int number) : this()
        {
            this.Age = number;
        }

        public Person(string name, int number)  
        {
            this.Name = name;
            this.Age = number;
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
