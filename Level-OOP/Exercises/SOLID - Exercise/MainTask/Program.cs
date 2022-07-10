using MainTask.Appenders;
using MainTask.Appenders.Interfaces;
using MainTask.Factory;
using MainTask.Layouts;
using MainTask.Layouts.Interfaces;
using MainTask.LogFiles;
using MainTask.LogFiles.Interfaces;
using MainTask.Loggers;
using MainTask.Loggers.Interfaces;
using MainTask.ReportLevel;
using System;

namespace MainTask
{
    public class StartUp
    {
        static void Main()
        {
            //Test Driven Development

            //{0} - {1} - {2}
            //ILayout simpleLayout = new SimpleLayout();

            //Layout - Console.WriteLine
            //IAppender consoleAppender = new ConsoleAppender(simpleLayout);

            //Appender
            //ILogger logger = new Logger(consoleAppender);

            //logger.Error("3/26/2015 2:08:11 PM", "Error parsing JSON.");
            //logger.Info("3/26/2015 2:08:11 PM", "User Pesho successfully registered.");

            //-----------------------------------------------------------

            //var simpleLayout = new SimpleLayout();
            //var consoleAppender = new ConsoleAppender(simpleLayout);

            //var file = new LogFile();
            //var fileAppender = new FileAppender(simpleLayout, file);

            //var logger = new Logger(consoleAppender, fileAppender);
            //logger.Error("3/26/2015 2:08:11 PM", "Error parsing JSON.");
            //logger.Info("3/26/2015 2:08:11 PM", "User Pesho successfully registered.");

            //------------------------------------------------------------

            //var xmlLayout = new XmlLayout();
            //var consoleAppender = new ConsoleAppender(xmlLayout);
            //var logger = new Logger(consoleAppender);

            //logger.Fatal("3/31/2015 5:23:54 PM", "mscorlib.dll does not respond");
            //logger.Critical("3/31/2015 5:23:54 PM", "No connection string found in App.config");


            //-------------------------------------------------------------

            //var simpleLayout = new SimpleLayout();
            //var consoleAppender = new ConsoleAppender(simpleLayout);
            //consoleAppender.ReportLevel = LogLevel.Error;

            //var logger = new Logger(consoleAppender);

            //logger.Info("3/31/2015 5:33:07 PM", "Everything seems fine");
            //logger.Warning("3/31/2015 5:33:07 PM", "Warning: ping is too high - disconnect imminent");
            //logger.Error("3/31/2015 5:33:07 PM", "Error parsing request");
            //logger.Critical("3/31/2015 5:33:07 PM", "No connection string found in App.config");
            //logger.Fatal("3/31/2015 5:33:07 PM", "mscorlib.dll does not respond");

            //-------------------------------------------------------------

            //var simpleLayout = new SimpleLayout();

            //var logFile = new LogFile();

            //var consoleAppender = new FileAppender(simpleLayout, logFile);

            //consoleAppender.ReportLevel = LogLevel.Error;

            //var logger = new Logger(consoleAppender);

            //logger.Info("3/31/2015 5:33:07 PM", "Everything seems fine");
            //logger.Warning("3/31/2015 5:33:07 PM", "Warning: ping is too high - disconnect imminent");
            //logger.Error("3/31/2015 5:33:07 PM", "Error parsing request");
            //logger.Critical("3/31/2015 5:33:07 PM", "No connection string found in App.config");
            //logger.Fatal("3/31/2015 5:33:07 PM", "mscorlib.dll does not respond");

            //System.Console.WriteLine(logFile.Size);

            //-------------------------------------------------------------

            LayoutFactory layoutFactory = new LayoutFactory();
            AppenderFactory appenderFactory = new AppenderFactory();

            ILogger logger = new Logger();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] appenderInfo = Console.ReadLine()
                    .Split();

                string type = appenderInfo[0];
                string layout = appenderInfo[1];

                ILayout layoutType = layoutFactory.Create(layout);
                IAppender appender = appenderFactory.Create(type, layout);

                //this is if i do not use factory - design pattern :

                //if (layout == "SimpleLayout")
                //{
                //    layoutType = new SimpleLayout();
                //}
                //else if (layout == "XmlLayout")
                //{
                //    layoutType = new XmlLayout();
                //}

                //if (type == "ConsoleAppender")
                //{
                //    appender = new ConsoleAppender(layoutType);
                //}
                //else if (type == "FileAppender")
                //{
                //    ILogFile logfile = new LogFile();
                //    appender = new FileAppender(layoutType, logfile);
                //}

                if (appenderInfo.Length == 3)
                {
                    bool isValidLogLevel = Enum.TryParse(
                        appenderInfo[2], ignoreCase: true, out LogLevel logLevel);

                    if (isValidLogLevel)
                    {
                        appender.ReportLevel = logLevel;
                    }
                }
                logger.Appenders.Add(appender);
            }

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] messageInfo = input.Split('|');

                string logLevel = messageInfo[0];
                string date = messageInfo[1];
                string message = messageInfo[2];

                bool isValidLogLevel = Enum.TryParse(
                        logLevel, ignoreCase: true, out LogLevel messageLogLevel);

                if (!isValidLogLevel)
                {
                    continue;
                }

                //Factory - design pattern
                if (messageLogLevel == LogLevel.Info)
                {
                    logger.Info(date, message);
                }
                else if (messageLogLevel == LogLevel.Warning)
                {
                    logger.Warning(date, message);
                }
                else if (messageLogLevel == LogLevel.Critial)
                {
                    logger.Critical(date, message);
                }
                else if (messageLogLevel == LogLevel.Error)
                {
                    logger.Critical(date, message);
                }
                else if (messageLogLevel == LogLevel.Fatal)
                {
                    logger.Fatal(date, message);
                }
            }

            Console.WriteLine("Logger info");
            Console.WriteLine(logger.GetLoggerInfo());
        }
    }
}
