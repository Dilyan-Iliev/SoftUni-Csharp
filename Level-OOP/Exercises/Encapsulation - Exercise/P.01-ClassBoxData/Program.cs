using PracticeForJudge.Core;
using PracticeForJudge.Core.Interfaces;
using PracticeForJudge.IO;
using PracticeForJudge.IO.Interfaces;
using PracticeForJudge.Models;

namespace PracticeForJudge
{
    public class StartUp
    {
        static void Main()
        {
            IWriter writer = new Writer();
            IReader reader = new Reader();
            IController controller = new Controller();

            IEngine engine = new Engine(writer, reader, controller);
            engine.Run();
        }
    }
}
