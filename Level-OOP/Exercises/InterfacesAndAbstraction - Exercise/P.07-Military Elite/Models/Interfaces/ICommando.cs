using System.Collections.Generic;

namespace LocalPractice.Models.Interfaces
{
    public interface ICommando : ISpecialisedSoldier
    {
        List<IMission> Missions { get; set; }

        void CompleteMission(string codeName);
    }
}
