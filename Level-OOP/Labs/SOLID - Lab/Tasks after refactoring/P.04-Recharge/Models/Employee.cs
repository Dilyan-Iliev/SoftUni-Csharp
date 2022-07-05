using P._04_Recharge.Interfaces;

namespace P._04_Recharge.Models
{
    public class Employee : Worker, ISleeper
    {
        public Employee(string iD) 
            : base(iD)
        {
        }

        public string Sleep() => "Sleep..";
    }
}
