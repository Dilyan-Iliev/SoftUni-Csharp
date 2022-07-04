using PracticeForJudge.IO.Interfaces;
using System;

namespace PracticeForJudge.IO
{
    public class Reader : IReader
    {
        public string ReadLine()
        => Console.ReadLine();
        
    }
}
