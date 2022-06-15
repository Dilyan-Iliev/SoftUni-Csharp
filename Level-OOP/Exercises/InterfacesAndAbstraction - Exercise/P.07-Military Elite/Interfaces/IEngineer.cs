using System.Collections.Generic;

namespace P._07_Military_Elite.Interfaces
{
    public interface IEngineer : ISpecialisedSoldier
    {
        List<IRepair> Repairs { get; set; }
    }
}
