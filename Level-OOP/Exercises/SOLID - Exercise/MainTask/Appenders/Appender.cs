using MainTask.Appenders.Interfaces;
using MainTask.Layouts.Interfaces;
using MainTask.ReportLevel;

namespace MainTask.Appenders
{
    public abstract class Appender : IAppender
    {
        protected Appender(ILayout layout)
        {
            this.Layout = layout;
        }
        public ILayout Layout { get;  }

        public LogLevel ReportLevel { get; set; }

        public int Count { get; protected set; } 
        //protected set, за да може в този клас, както и там където
        //се наследява да може да се edit-ва Count-а

        public abstract void Append(string datetime, LogLevel reportLevel, string message);

        public virtual string GetAppenderInfo()
        => $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {this.ReportLevel.GetType().Name}, Messages appended: {Count}";
    }
}
