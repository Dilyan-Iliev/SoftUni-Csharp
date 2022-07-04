using _4.Core.Interfaces;
using PersonsInfo.Core;

namespace PersonsInfo
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
