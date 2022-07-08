using LocalPractice.Models.Enumerators;
using LocalPractice.Models.Interfaces;

namespace LocalPractice.Models.Abstract_classes
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
