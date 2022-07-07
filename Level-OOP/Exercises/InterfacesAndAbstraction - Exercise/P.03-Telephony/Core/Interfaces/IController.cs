using PracticeForJudge.Models;

namespace PracticeForJudge.Core.Interfaces
{
    public interface IController
    {
        Smartphone CreateSmartphone();
        StationaryPhone CreateStationaryPhone();
    }
}
