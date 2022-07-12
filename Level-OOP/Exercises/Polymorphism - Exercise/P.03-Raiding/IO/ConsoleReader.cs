namespace _8.IO
{
    using System;
    using _8.IO.Interfaces;

    public class ConsoleReader : IReader
    {
        public string ReadLine()
         => Console.ReadLine();
    }
}
