using System;
using System.Collections.Generic;
using System.Text;

namespace P._07_Raw_Data
{
    public class Tire
    {
        public Tire(double pressure, int age)
        {
            this.Pressure = pressure;
            this.Age = age;
        }
        //Fields
        private int age;
        private double pressure;

        //Properties
        public int Age
        {
            get { return this.age; }
            set { this.age = value; }
        }
        public double Pressure
        {
            get { return this.pressure; }
            set { this.pressure = value; }
        }
    }
}
