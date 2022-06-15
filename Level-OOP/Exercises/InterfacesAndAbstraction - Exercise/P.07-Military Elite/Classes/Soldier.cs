using P._07_Military_Elite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace P._07_Military_Elite.Classes
{
    public abstract class Soldier : ISoldier
    {//абстрактен е понеже не ми трябва да създам просто войник, а да създам конкретен тип войник
        protected Soldier(int iD, string firstName, string lastName)
        {//конструктора ми е protected, a не public понеже имам абстрактен клас
            this.ID = iD;
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public int ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
