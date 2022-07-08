using LocalPractice.Models.Abstract_classes;
using LocalPractice.Models.Interfaces;
using System.Text;

namespace LocalPractice.Models
{
    public class Spy : Soldier, ISpy
    {
        public Spy(int iD, string firstName, string lastName, int codeNumber)
            : base(iD, firstName, lastName)
        {
            this.CodeNumber = codeNumber;
        }

        public int CodeNumber { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Name: {FirstName} {LastName} Id: {ID}");
            sb.Append($"Code Number: {CodeNumber}");
            return sb.ToString();
        }
    }
}
