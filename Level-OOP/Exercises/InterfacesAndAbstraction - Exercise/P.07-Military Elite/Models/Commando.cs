using LocalPractice.Models.Abstract_classes;
using LocalPractice.Models.Enumerators;
using LocalPractice.Models.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LocalPractice.Models
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        public Commando(int iD, string firstName, string lastName, decimal salary, Corps corps)
            : base(iD, firstName, lastName, salary, corps)
        {
            this.Missions = new List<IMission>();
        }

        public List<IMission> Missions { get; set; }

        public void CompleteMission(string codeName)
        {
            var mission = this.Missions
                .FirstOrDefault(x => x.CodeName == codeName);
            mission.MissionStatus = MissionStatus.Finished;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            string baseInfo = base.ToString();

            sb.AppendLine(baseInfo);
            sb.AppendLine($"Corps: {Corps}");
            sb.AppendLine("Missions:");

            foreach (var mission in Missions)
            {
                sb.AppendLine($"  {mission.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
