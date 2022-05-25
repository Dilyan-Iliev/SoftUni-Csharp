using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    public class Person
    {
        private int age;
        private string name;
        public Person(int age, string name)
        {
            this.Age = age;
            this.Name = name;
        }
        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                //if (value < 0)
                //{
                //    throw new Exception();
                //}

                this.age = value;
            }
        }
        public string Name { get; set; }


        public override string ToString()
        {
            return $"Name: {this.Name}, Age: {this.Age}";
        }
    }
}
