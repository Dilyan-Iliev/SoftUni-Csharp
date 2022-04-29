using System;
using System.Collections.Generic;
using System.Text;

namespace P._08_Car_Salesman
{
    public class Engine
    {
        //Constructors
        public Engine(string engineModel, int enginePower)
        {
            this.EngineModel = engineModel;
            this.EnginePower = enginePower;
            this.Displacement = 0;
            this.Efficiency = "n/a";
        }
        public Engine(string engineModel, int enginePower, int displacement)
            : this(engineModel, enginePower)
        {
            this.Displacement = displacement;
        }
        public Engine(string engineModel, int enginePower, string efficiency)
            : this(engineModel, enginePower)
        {
            this.Efficiency = efficiency;
        }
        public Engine(string engineModel, int enginePower,
            int displacement, string efficiency) : this(engineModel, enginePower)
        {
            this.Displacement = displacement;
            this.Efficiency = efficiency;
        }

        //Fields
        private string engineModel;
        private int enginePower;
        private int displacement;
        private string efficiency;

        //Properties
        public string EngineModel
        {
            get { return this.engineModel; }
            set { this.engineModel = value; }
        }
        public int EnginePower
        {
            get { return this.enginePower; }
            set { this.enginePower = value; }
        }
        public int Displacement
        {
            get { return this.displacement; }
            set { this.displacement = value; }
        }
        public string Efficiency
        {
            get { return this.efficiency; }
            set { this.efficiency = value; }
        }
    }
}
