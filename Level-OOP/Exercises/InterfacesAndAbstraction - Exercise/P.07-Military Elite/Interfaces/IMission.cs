using P._07_Military_Elite.Enums;

namespace P._07_Military_Elite.Interfaces
{
    public interface IMission
    {
        string CodeName { get; }
        MissionStatus MissionStatus { get; set; }
    }
}
