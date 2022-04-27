using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturer
{
    public class Car
    {
        //Constructor 
        public Car(string make, string model, int year, double fuelQuantity
            , double fuelConsumption, Engine engineIndex, Tire tiresIndex)
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
            this.EngineIndex = engineIndex;
            this.TiresIndex = tiresIndex;
        }

        //Fields
        private string make;
        private string model;
        private int year;
        private double fuelQuantity;
        private double fuelConsumption;
        private Engine engineIndex;
        private Tire tiresIndex;
        
        //Properties
        public string Make
        {
            get { return this.make; }
            set { this.make = value; }
        }
        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }
        public int Year
        {
            get { return this.year; }
            set { this.year = value; }
        }
        public double FuelQuantity
        {
            get { return this.fuelQuantity; }
            set { this.fuelQuantity = value; }
        }
        public double FuelConsumption
        {
            get { return this.fuelConsumption; }
            set { this.fuelConsumption = value; }
        }
        public Engine EngineIndex 
        { 
            get { return this.engineIndex; }
            set { this.engineIndex = value; }
        }
        public Tire TiresIndex 
        { 
            get { return this.tiresIndex; }
            set { this.tiresIndex = value; }
        }

        //Methods
        public double Drive20Kilometers(double fuelQuantity, double fuelConsumption)
        {
            fuelQuantity -= (this.FuelConsumption / 100) * 20;

            return fuelQuantity;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Make: {this.Make}");
            sb.AppendLine($"Year: {this.Year}");
            sb.AppendLine($"HorsePowers: {this.EngineIndex.HorsePower}");
            sb.Append($"FuelQuantity: {this.Drive20Kilometers(FuelQuantity, FuelConsumption)}");

            return sb.ToString();
        }
    }
}

