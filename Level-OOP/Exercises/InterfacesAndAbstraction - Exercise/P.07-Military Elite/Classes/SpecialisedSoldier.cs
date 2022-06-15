using P._07_Military_Elite.Enums;
using P._07_Military_Elite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace P._07_Military_Elite.Classes
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        protected SpecialisedSoldier(int iD, string firstName, string lastName, decimal salary, Corps corps) 
            : base(iD, firstName, lastName, salary)
        {
            this.Corps = corps;
        }

        public Corps Corps { get; set; }
    }
}
