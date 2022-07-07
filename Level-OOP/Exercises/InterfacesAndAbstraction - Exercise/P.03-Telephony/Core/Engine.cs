using System;
using PracticeForJudge.IO;
using PracticeForJudge.Models;
using PracticeForJudge.Core.Interfaces;
using PracticeForJudge.IO.Interfaces;

namespace PracticeForJudge.Core
{
    public class Engine : IEngine
    {
        private readonly IWriter writer;
        private readonly IReader reader;
        private readonly IController controller;

        public Engine()
        {
            this.writer = new Writer();
            this.reader = new Reader();
            this.controller = new Controller();
        }
        public void Run()
        {
            Smartphone sp = controller.CreateSmartphone();
            StationaryPhone stp = controller.CreateStationaryPhone();

            var numbers = reader.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var URLs = reader.ReadLine()
                 .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            foreach (var number in numbers)
            {
                try
                {
                    if (number.Length == 7)
                    {
                        writer.WriteLine(stp.Call(number));
                    }
                    else if (number.Length == 10)
                    {
                        writer.WriteLine(sp.Call(number));
                    }
                }
                catch (ArgumentException ae)
                {
                    writer.WriteLine(ae.Message);
                }
            }

            foreach (var URL in URLs)
            {
                try
                {
                    writer.WriteLine(sp.Browse(URL));
                }
                catch (ArgumentException ae)
                {
                    writer.WriteLine(ae.Message);
                }
            }
        }
    }
}
