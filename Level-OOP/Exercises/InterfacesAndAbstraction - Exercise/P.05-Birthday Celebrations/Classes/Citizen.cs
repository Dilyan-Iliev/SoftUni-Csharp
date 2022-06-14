using P._05_Birthday_Celebrations.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace P._05_Birthday_Celebrations.Classes
{
    public class Citizen : IInformational, IIdentifiable
    {
        public Citizen(string name, int age, string id, string birthdate)
        {
            Name = name;
            Age = age;
            ID = id;
            Birthdate = birthdate;
        }

        public string Name { get; private set; }
        public string Birthdate { get; private set; }
        public int Age { get; private set; }
        public string ID { get; private set; }
    }
}
