namespace _8.IO.Interfaces
{
    using System;

    public interface IWriter
    {
        void Write(object value);   
        void WriteLine(object value);
    }
}
