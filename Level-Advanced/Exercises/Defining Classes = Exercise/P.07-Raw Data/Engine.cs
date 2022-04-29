using System;
using System.Collections.Generic;
using System.Text;

namespace P._07_Raw_Data
{
    public class Engine
    {
        public Engine(int speed, int power)
        {
            this.Speed = speed;
            this.Power = power;
        }
        //Fields
        private int speed;
        private int power;

        //Properties
        public int Speed
        {
            get { return this.speed; }
            set { this.speed = value; }
        }
        public int Power
        {
            get { return this.power; }
            set { this.power = value; }
        }
    }
}
