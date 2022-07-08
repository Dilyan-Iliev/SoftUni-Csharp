using LocalPractice.IO.Interfaces;
using System;

namespace LocalPractice.IO
{
    public class ConsoleWriter : IWriter
    {
        public void Write(object value)
         => Console.Write(value);

        public void WriteLine(object value)
         => Console.WriteLine(value);
    }
}
