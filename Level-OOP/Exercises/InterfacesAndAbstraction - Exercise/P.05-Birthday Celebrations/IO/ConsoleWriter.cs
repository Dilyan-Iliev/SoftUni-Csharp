using _7.IO.Interfaces;
using System;

namespace _7.IO
{
    public class ConsoleWriter : IWriter
    {
        public void Write(object value)
         => Console.Write(value);

        public void WriteLine(object value)
         => Console.WriteLine(value);
    }
}
