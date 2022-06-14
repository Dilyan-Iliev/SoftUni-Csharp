using P._05_Birthday_Celebrations.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace P._05_Birthday_Celebrations.Classes
{
    public class Robot : IIdentifiable
    {
        public Robot(string model, string iD)
        {
            Model = model;
            ID = iD;
        }

        public string Model { get; private set; }
        public string ID { get; private set; }
    }
}
