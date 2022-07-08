using LocalPractice.Models.Abstract_classes;
using LocalPractice.Models.Interfaces;

namespace LocalPractice.Models
{
    public class Private : Soldier, IPrivate
    {//наследявам IPrivate, а не ISoldier, понеже IPrivate наследява ISoldier
        //освен това не имплементирам всичко което го има в IPrivate, понеже наследявам Soldier, който е имплементирал този интерфейс
        public Private(int iD, string firstName, string lastName, decimal salary)
            : base(iD, firstName, lastName)
        {
            this.Salary = salary;
        }

        public decimal Salary { get; set; }

        public override string ToString()
        {
            return $"Name: {this.FirstName} {this.LastName} Id: {this.ID} Salary: {this.Salary:f2}";
        }
    }
}
