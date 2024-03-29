﻿namespace PracticeForJudge.IO
{
    using System;
    using PracticeForJudge.IO.Interfaces;

    public class ConsoleWriter : IWriter
    {
        public void Write(object value)
         => Console.Write(value);

        public void WriteLine(object value)
         => Console.WriteLine(value);
    }
}
