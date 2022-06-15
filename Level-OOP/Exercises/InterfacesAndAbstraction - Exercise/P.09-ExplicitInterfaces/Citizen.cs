using System;
using System.Collections.Generic;
using System.Text;

namespace P._09_ExplicitInterfaces
{
    public class Citizen : IResident, IPerson
    {

        string IResident.Name { get; set; }

        public string Country { get; set; }



        string IPerson.Name { get; set; }

        public int Age { get; set; }



        string IResident.GetName(string name)
        {
            return $"Mr/Ms/Mrs {name}";
        }

        string IPerson.GetName(string name)
        {
            return name;
        }
    }
}
