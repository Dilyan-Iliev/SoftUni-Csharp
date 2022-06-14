using P._06_Food_Shortage.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace P._06_Food_Shortage.Classes
{
    public class Citizen : IInformational, IBuyer
    {
        private const int FoodIncrease = 10;
        private int amountOfFood = 0;
        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.ID = id;
            this.BirthDate = birthdate;
        }
        public string Name { get; private set; }
        public int Age { get; private set; }
        public string ID { get; private set; }
        public string BirthDate { get; private set; }

        public int BuyFood()
        {
            return FoodIncrease;
        }
    }
}
