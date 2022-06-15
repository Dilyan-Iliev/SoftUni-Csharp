using P._07_Military_Elite.Enums;
using P._07_Military_Elite.Interfaces;

namespace P._07_Military_Elite.Classes
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
