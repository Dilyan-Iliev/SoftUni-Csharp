using MainTask.Appenders.Interfaces;
using System.Collections.Generic;

namespace MainTask.Loggers.Interfaces
{
    public interface ILogger
    {
        List<IAppender> Appenders { get; }

        void Info(string datetime, string message);

        void Error(string datetime, string message);

        void Warning(string datetime, string message);

        void Critical(string datetime, string message);

        void Fatal(string datetime, string message);

        string GetLoggerInfo();
    }
}
