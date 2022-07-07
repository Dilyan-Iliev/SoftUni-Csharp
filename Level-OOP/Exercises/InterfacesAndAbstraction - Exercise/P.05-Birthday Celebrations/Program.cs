using _7.Core;
using _7.Core.Interfaces;
using System;

namespace _7
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
