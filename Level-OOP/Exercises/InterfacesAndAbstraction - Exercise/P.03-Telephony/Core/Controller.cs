using PracticeForJudge.Core.Interfaces;
using PracticeForJudge.Models;

namespace PracticeForJudge.Core
{
    public class Controller : IController
    {
        public Smartphone CreateSmartphone()
         => new Smartphone();

        public StationaryPhone CreateStationaryPhone()
         => new StationaryPhone();
    }
}
