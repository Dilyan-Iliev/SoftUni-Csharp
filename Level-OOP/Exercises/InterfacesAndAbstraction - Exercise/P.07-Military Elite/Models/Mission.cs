using LocalPractice.Models.Enumerators;
using LocalPractice.Models.Interfaces;

namespace LocalPractice.Models
{
    public class Mission : IMission
    {
        public Mission(string codeName, MissionStatus missionStatus)
        {
            CodeName = codeName;
            MissionStatus = missionStatus;
        }

        public string CodeName { get; private set; }

        public MissionStatus MissionStatus { get; set; }

        public override string ToString()
        {
            return $"Code Name: {CodeName} State: {MissionStatus}";
        }
    }
}
