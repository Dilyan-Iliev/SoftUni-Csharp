using LocalPractice.Models.Abstract_classes;
using LocalPractice.Models.Enumerators;
using LocalPractice.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LocalPractice.Models
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        public Engineer(int iD, string firstName, string lastName, decimal salary, Corps corps)
            : base(iD, firstName, lastName, salary, corps)
        {
            this.Repairs = new List<IRepair>();
        }

        public List<IRepair> Repairs { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            string baseInfo = base.ToString();

            sb.AppendLine(baseInfo);
            sb.AppendLine($"Corps: {Corps}");
            sb.AppendLine("Repairs:");

            foreach (var repair in Repairs)
            {
                sb.AppendLine($"  {repair.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
