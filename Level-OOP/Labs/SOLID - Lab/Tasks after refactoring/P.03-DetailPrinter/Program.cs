using P._03_DetailPrinter.Interfaces;
using P._03_DetailPrinter.Models;
using System.Collections.Generic;

namespace P._03_DetailPrinter
{
    public class Program
    {
        static void Main(string[] args)
        {
            var employees = new List<IEmployeeType>();

            IEmployeeType manager = new Manager("George", new List<string>
            {
                "PDF document",
                "Word document"
            });

            IEmployeeType employee = new Employee("Peter");

            employees.Add(manager);
            employees.Add(employee);

            DetailsPrinter dp = new DetailsPrinter(employees);
            dp.PrintDetails();
        }
    }
}
