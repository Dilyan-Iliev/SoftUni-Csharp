using PracticeForJudge.Core;
using PracticeForJudge.Core.Interfaces;
using System;

namespace PracticeForJudge
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
