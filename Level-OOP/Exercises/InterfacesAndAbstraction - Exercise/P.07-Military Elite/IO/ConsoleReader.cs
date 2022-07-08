using LocalPractice.IO.Interfaces;
using System;

namespace LocalPractice.IO
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
         => Console.ReadLine();
    }
}
