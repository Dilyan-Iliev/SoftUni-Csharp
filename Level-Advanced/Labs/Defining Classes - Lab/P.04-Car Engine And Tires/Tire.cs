using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturer
{
    public class Tire
    {
        //Constructor-----------
        public Tire(int year, double pressure)
        {
            this.Year = year;
            this.Pressure = pressure;
        }

        //Fields---------------
        private int year;
        private double pressure;

        //Properties------------
        public int Year
        {
            get 
            { 
                return this.year;
            }
            set 
            {
                this.year = value;
            }
        }
        public double Pressure
        {
            get
            {
                return this.pressure;
            }
            set
            {
                this.pressure = value;
            }
        }
    }
}
