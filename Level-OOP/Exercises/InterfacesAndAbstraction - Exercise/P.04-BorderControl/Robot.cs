using System;
using System.Collections.Generic;
using System.Text;

namespace P._04_BorderControl
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
