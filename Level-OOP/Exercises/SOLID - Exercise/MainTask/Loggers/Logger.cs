using MainTask.Appenders.Interfaces;
using MainTask.Loggers.Interfaces;
using MainTask.ReportLevel;
using System.Collections.Generic;
using System.Text;

namespace MainTask.Loggers
{
    public class Logger : ILogger
    {
        public Logger(params IAppender[] appenders)
        {
            Appenders = new List<IAppender>();
            this.Appenders.AddRange(appenders);
        }

        public List<IAppender> Appenders { get; }

        public void Critical(string datetime, string message)
        {
            Log(datetime, LogLevel.Critial, message);
        }

        public void Error(string datetime, string message)
        {
            Log(datetime, LogLevel.Error, message);
        }

        public void Fatal(string datetime, string message)
        {
            Log(datetime, LogLevel.Fatal, message);
        }

        public void Info(string datetime, string message)
        {
            Log(datetime, LogLevel.Info, message);
        }

        public void Warning(string datetime, string message)
        {
            Log(datetime, LogLevel.Warning, message);
        }

        public string GetLoggerInfo()
        {
            var sb = new StringBuilder();

            foreach (var appender in Appenders)
            {
                sb.AppendLine(appender.GetAppenderInfo());
            }

            return sb.ToString().TrimEnd();
        }

        private void Log(string datetime, LogLevel logLevel, string message)
        {
            foreach (var appender in Appenders)
            {
                if (logLevel >= appender.ReportLevel)
                {
                    appender.Append(datetime, logLevel, message);
                }
            }
        }
    }
}
