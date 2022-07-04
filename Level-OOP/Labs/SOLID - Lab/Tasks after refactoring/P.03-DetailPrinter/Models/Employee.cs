using P._03_DetailPrinter.Interfaces;

namespace P._03_DetailPrinter.Models
{
    public class Employee : IEmployeeType
    {
        public Employee(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public string PrintEmployee()
         => this.Name;
    }
}
