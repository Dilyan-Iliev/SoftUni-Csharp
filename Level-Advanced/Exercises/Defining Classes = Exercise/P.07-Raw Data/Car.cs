using System;
using System.Collections.Generic;
using System.Text;

namespace P._07_Raw_Data
{
    public class Car
    {
        public Car(string model, Engine engine, Cargo cargo, Tire[] tires)
        {
            this.Model = model;
            this.Engine = engine;
            this.Cargo = cargo;
            this.tires = tires;
        }
        //Fields
        private string model;
        private Engine engine;
        private Cargo cargo;
        private Tire[] tires;

        //Properties
        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }
        public Engine Engine
        {
            get { return this.engine; }
            set { this.engine = value; }
        }
        public Cargo Cargo
        {
            get { return this.cargo; }
            set { this.cargo = value; }
        }
        public Tire[] Tires
        {
            get { return this.tires; }
            set { this.tires = value; }
        }
    }
}
