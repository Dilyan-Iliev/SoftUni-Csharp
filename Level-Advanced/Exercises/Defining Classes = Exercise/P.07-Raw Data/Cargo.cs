using System;
using System.Collections.Generic;
using System.Text;

namespace P._07_Raw_Data
{
    public class Cargo
    {
        public Cargo(int weight, string type)
        {
            this.Type = type;
            this.Weight = weight;
        }
        //Fields
        private string type;
        private int weight;

        //Properties
        public string Type
        {
            get { return this.type; }
            set { this.type = value; }
        }
        public int Weight
        {
            get { return this.weight; }
            set { this.weight = value; }
        }
    }
}
