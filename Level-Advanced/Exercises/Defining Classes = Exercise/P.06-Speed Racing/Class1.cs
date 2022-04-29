using System;
using System.Collections.Generic;
using System.Text;

namespace P._06_Speed_Racing
{
    public class Car
    {
        public Car(string model, double fuelAmout, double fuelConsumption)
        {
            this.Model = model;
            this.FuelAmount = fuelAmout;
            this.FuelConstumptionPerKilometer = fuelConsumption;
            this.TravelledDistance = 0;

        }
        //Fields
        private string model;
        private double fuelAmount;
        private double fuelConsumptionPerKilometer;
        private double travelledDistance;


        //Properties
        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }
        public double FuelAmount
        {
            get { return this.fuelAmount; }
            set { this.fuelAmount = value; }
        }
        public double FuelConstumptionPerKilometer
        {
            get { return this.fuelConsumptionPerKilometer; }
            set { this.fuelConsumptionPerKilometer = value; }
        }
        public double TravelledDistance
        {
            get { return this.travelledDistance; }
            set { this.travelledDistance = value; }
        }

        public void CheckForDistance(double distance)
        {
            bool check = this.FuelConstumptionPerKilometer * distance <= this.FuelAmount;

            if (check)
            {
                this.FuelAmount -= this.FuelConstumptionPerKilometer * distance;
                TravelledDistance += distance;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }
}
