using _5.IO.Interfaces;
using System;

namespace PersonsInfo.IO
{
    public class Reader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
