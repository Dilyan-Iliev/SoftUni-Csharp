using System;
using System.Collections.Generic;
using System.Text;

namespace P._08_Car_Salesman
{
    public class Car
    {
        //Constructors
        public Car(string model, Engine engine)
        {
            this.Model = model;
            this.Engine = engine;
            this.Weight = 0;
            this.Color = "n/a";
        }
        public Car(string model, Engine engine, int weight) : this(model, engine)
        {
            this.Weight = weight;
        }
        public Car(string model, Engine engine, string color) : this(model, engine)
        {
            this.Color = color;
        }
        public Car(string model, Engine engine, int weigth, string color) : this(model, engine)
        {
            this.Weight = weigth;
            this.Color = color;
        }

        //Fields
        private string model;
        private Engine engine;
        private int weight;
        private string color;

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
        public int Weight
        {
            get { return this.weight; }
            set { this.weight = value; }
        }
        public string Color
        {
            get { return this.color; }
            set { this.color = value; }
        }

        //Methods
        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{this.Model}:");
            sb.AppendLine($"  {this.Engine.EngineModel}:");
            sb.AppendLine($"    Power: {this.Engine.EnginePower}");
            sb.AppendLine(this.Engine.Displacement == 0 ? $"    Displacement: n/a" : $"    Displacement: {this.Engine.Displacement}");
            //this means if engine.Displacement == 0 -> do $"    Displacement: n/a" else do $"    Displacement: {this.Engine.Displacement}"
            sb.AppendLine($"    Efficiency: {this.Engine.Efficiency}");
            sb.AppendLine(this.Weight == 0 ? $"  Weight: n/a" : $"  Weight: {this.Weight}");
            sb.Append($"  Color: {this.Color}");

            return sb.ToString();
        }
    }
}
