using System;
using System.IO;
using MainTask.Layouts.Interfaces;
using MainTask.LogFiles.Interfaces;
using MainTask.ReportLevel;

namespace MainTask.Appenders
{
    public class FileAppender : Appender
    {
        //my file path : 
        private const string FilePath = "../../../Output/result.txt";

        public FileAppender(ILayout layout, ILogFile logfile) 
            : base(layout)
        {
            LogFile = logfile;
        }

        public ILogFile LogFile { get; }

        public override void Append(string datetime, LogLevel reportLevel, string message)
        {
            string appendMessage = string.Format(this.Layout.Format, datetime, reportLevel, message);

            this.Count++;

            LogFile.Write(appendMessage);

            File.AppendAllText(FilePath, appendMessage + Environment.NewLine);
        }

        public override string GetAppenderInfo()
        {
            return base.GetAppenderInfo() + $", File size: {LogFile.Size}";
        }
    }
}
