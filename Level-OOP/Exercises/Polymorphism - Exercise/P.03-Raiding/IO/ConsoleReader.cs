namespace PracticeForJudge.IO
{
    using System;
    using PracticeForJudge.IO.Interfaces;

    public class ConsoleReader : IReader
    {
        public string ReadLine()
         => Console.ReadLine();
    }
}
