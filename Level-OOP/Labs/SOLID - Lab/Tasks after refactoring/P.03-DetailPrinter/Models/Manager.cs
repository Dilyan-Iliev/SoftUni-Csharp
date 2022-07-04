using P._03_DetailPrinter.Interfaces;
using System.Collections.Generic;

namespace P._03_DetailPrinter.Models
{
    public class Manager : IEmployeeType
    {
        public Manager(string name, ICollection<string> documents)
        {
            Name = name;
            Documents = new List<string>(documents);
        }

        public string Name { get; set; }
        public IReadOnlyCollection<string> Documents { get; set; }

        public string PrintEmployee()
        => this.Name;
    }
}
