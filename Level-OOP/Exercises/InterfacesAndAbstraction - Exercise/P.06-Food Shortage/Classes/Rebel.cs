using P._06_Food_Shortage.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace P._06_Food_Shortage.Classes
{
    public class Rebel : IInformational, IBuyer
    {
        private const int FoodIncrease = 5;
        private int amountOfFood = 0;

        public Rebel(string name, int age, string group)
        {
            this.Name = name;
            this.Age = age;
            this.Group = group;
        }

        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Group { get; private set; }

        public int BuyFood()
        {
            return FoodIncrease;
        }
    }
}
