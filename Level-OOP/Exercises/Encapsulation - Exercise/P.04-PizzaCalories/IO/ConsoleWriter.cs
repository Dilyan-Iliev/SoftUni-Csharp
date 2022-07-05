using _5.IO.Interfaces;
using System;

namespace _5.IO
{
    public class ConsoleWriter : IWriter
    {
        public void Write(object value)
        => Console.Write(value);

        public void WriteLine(object value)
        => Console.WriteLine(value);
    }
}
