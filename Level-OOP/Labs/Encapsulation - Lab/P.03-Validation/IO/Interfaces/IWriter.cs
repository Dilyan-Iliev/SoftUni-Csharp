using System;
using System.Collections.Generic;
using System.Text;

namespace _4.IO.Interfaces
{
    public interface IWriter
    {
        void Write(string message);
        void WriteLine(string message);
    }
}
