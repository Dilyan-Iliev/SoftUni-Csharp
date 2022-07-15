using PracticeForJudge.IO;
using PracticeForJudge.Core;
using PracticeForJudge.IO.Interfaces;
using PracticeForJudge.Core.Interfaces;

namespace PracticeForJudge
{
    public class StartUp
    {
        static void Main()
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            IEngine engine = new Engine(reader, writer);
            engine.Run();
        }
    }
}
