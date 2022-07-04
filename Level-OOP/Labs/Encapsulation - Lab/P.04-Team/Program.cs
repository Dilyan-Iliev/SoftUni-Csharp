using PersonsInfo.Core;
using PersonsInfo.IO;
using System;

namespace PersonsInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IReader reader = new Reader();
            IWriter writer = new Writer();
            IController controller = new Controller();
            IEngine engine = new Engine(reader, writer, controller);
            engine.Run();
        }
    }
}
