using MainTask.Appenders;
using MainTask.Appenders.Interfaces;
using MainTask.Layouts;
using MainTask.Layouts.Interfaces;
using MainTask.LogFiles;
using MainTask.LogFiles.Interfaces;
using System;

namespace MainTask.Factory
{
    public class AppenderFactory
    {
        public IAppender Create(string appenderType, string layoutType)
        {
            IAppender appender = null;
            ILayout layout = null;

            if (appenderType == nameof(ConsoleAppender))
            {
                if (layoutType == nameof(SimpleLayout))
                {
                    layout = new SimpleLayout();
                }
                else if (layoutType == nameof(XmlLayout))
                {
                    layout= new XmlLayout();
                }
                appender = new ConsoleAppender(layout);
            }

            else if (appenderType == nameof(FileAppender))
            {
                if (layoutType == nameof(SimpleLayout))
                {
                    layout = new SimpleLayout();
                }
                else if (layoutType == nameof(XmlLayout))
                {
                    layout = new XmlLayout();
                }

                ILogFile logFile = new LogFile();
                appender = new FileAppender(layout, logFile);
            }
            else
            {
                throw new ArgumentException("Invalid Appender type");
            }

            return appender;
        }
    }
}
