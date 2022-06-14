using P._05_Birthday_Celebrations.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace P._05_Birthday_Celebrations.Classes
{
    public class Pet : IInformational
    {
        public Pet(string name, string birthdate)
        {
            Name = name;
            Birthdate = birthdate;
        }

        public string Name { get; private set; }

        public string Birthdate { get; private set; }
    }
}
