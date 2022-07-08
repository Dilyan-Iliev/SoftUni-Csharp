using LocalPractice.Core;
using LocalPractice.Core.Interfaces;

namespace LocalPractice
{
    public class StartUp
    {
        static void Main()
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
