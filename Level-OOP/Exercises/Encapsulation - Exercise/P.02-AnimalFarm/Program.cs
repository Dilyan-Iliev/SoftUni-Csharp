using PracticeForJudge.Core;
using PracticeForJudge.Core.Interfaces;
using PracticeForJudge.IO;
using PracticeForJudge.IO.Interfaces;

namespace PracticeForJudge
{
    public class StartUp
    {
        static void Main()
        {
            IWriter writer = new ConsoleWriter();
            IReader reader = new ConsoleReader();
            IController controller = new Controller();

            IEngine engine = new Engine(writer, reader, controller);
            engine.Run();
        }
    }
}
