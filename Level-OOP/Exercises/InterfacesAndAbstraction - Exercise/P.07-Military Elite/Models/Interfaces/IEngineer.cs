using System.Collections.Generic;

namespace LocalPractice.Models.Interfaces
{
    public interface IEngineer : ISpecialisedSoldier
    {
        List<IRepair> Repairs { get; set; }
    }
}
