using PracticeForJudge.Core;
using PracticeForJudge.Core.Interfaces;

namespace PracticeForJudge
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
