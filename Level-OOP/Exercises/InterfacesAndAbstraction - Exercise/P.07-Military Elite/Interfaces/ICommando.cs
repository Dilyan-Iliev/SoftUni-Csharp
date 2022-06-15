using System.Collections.Generic;

namespace P._07_Military_Elite.Interfaces
{
    public interface ICommando : ISpecialisedSoldier
    {
        List<IMission> Missions { get; set; }

        void CompleteMission(string codeName);
    }
}
