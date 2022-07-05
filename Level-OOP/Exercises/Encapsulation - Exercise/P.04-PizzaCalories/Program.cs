using _5.Core;
using _5.Core.Interfaces;

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
