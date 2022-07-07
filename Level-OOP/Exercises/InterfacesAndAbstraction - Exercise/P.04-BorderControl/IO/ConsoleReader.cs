using _7.IO.Interfaces;
using System;

namespace _7.IO
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
         => Console.ReadLine();
    }
}
