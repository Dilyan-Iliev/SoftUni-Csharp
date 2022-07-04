using _4.IO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo.IO
{
    public class Writer : IWriter
    {
        public void Write(string message)
        {
            Console.Write(message);
        }

        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
