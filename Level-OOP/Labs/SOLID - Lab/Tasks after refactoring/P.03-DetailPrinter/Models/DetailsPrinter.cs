using P._03_DetailPrinter.Interfaces;
using System.Collections.Generic;

namespace P._03_DetailPrinter.Models
{
    public class DetailsPrinter
    {
        private readonly ICollection<IEmployeeType> employees;

        public DetailsPrinter(ICollection<IEmployeeType> employees)
        {
            this.employees = employees;
        }
        public void PrintDetails()
        {
            foreach (var employeeType in employees)
            {
                System.Console.WriteLine(employeeType.PrintEmployee());
            }
        }
    }
}
