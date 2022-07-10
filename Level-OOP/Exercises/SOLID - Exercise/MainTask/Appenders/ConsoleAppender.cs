using System;
using MainTask.Layouts.Interfaces;
using MainTask.ReportLevel;

namespace MainTask.Appenders
{
    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout) 
            : base(layout)
        {
        }

        public override void Append(string datetime, LogLevel reportLevel, string message)
        {
            this.Count++;
            Console.WriteLine(String.Format(this.Layout.Format, datetime, reportLevel, message));
        }
    }
}
