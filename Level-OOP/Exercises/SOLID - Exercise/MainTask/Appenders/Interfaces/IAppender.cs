using MainTask.Layouts.Interfaces;
using MainTask.ReportLevel;

namespace MainTask.Appenders.Interfaces
{
    public interface IAppender
    {
        ILayout Layout { get; }

        LogLevel ReportLevel { get; set; }

        void Append(string datetime, LogLevel reportLevel, string message);

        public int Count { get; }

        string GetAppenderInfo();
    }
}
