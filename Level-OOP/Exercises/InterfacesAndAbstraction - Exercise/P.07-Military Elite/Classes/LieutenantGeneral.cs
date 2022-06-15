using P._07_Military_Elite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace P._07_Military_Elite.Classes
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {//Private наследява Soldier, поради което и този клас наследява Soldier

        public LieutenantGeneral(int iD, string firstName, string lastName, decimal salary)
            : base(iD, firstName, lastName, salary)
        {
            this.Privates = new List<IPrivate>();
        }

        public List<IPrivate> Privates { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.ID} Salary: {this.Salary:f2}");
            //or base.ToString() -> това е метода ToString на базовия клас - родител

            sb.AppendLine("Privates:");

            foreach (var soldier in Privates)
            {
                sb.AppendLine($"  {soldier.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
