using _5.IO.Interfaces;
using System;

namespace _5.IO
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        => Console.ReadLine();
    }
}
