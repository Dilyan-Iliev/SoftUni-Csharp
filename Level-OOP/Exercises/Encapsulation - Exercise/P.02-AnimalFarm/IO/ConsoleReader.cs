using PracticeForJudge.IO.Interfaces;
using System;

namespace PracticeForJudge.IO
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        => Console.ReadLine();
    }
}
