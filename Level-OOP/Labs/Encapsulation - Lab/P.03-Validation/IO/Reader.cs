using _4.IO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

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
