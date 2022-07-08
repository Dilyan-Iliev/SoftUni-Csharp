using LocalPractice.Models.Enumerators;

namespace LocalPractice.Models.Interfaces
{
    public interface IMission
    {
        string CodeName { get; }
        MissionStatus MissionStatus { get; set; }
    }
}
