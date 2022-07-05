using System;
using PracticeForJudge.IO.Interfaces;

namespace PracticeForJudge.Core.Interfaces
{
    public class Engine : IEngine
    {
        private readonly IWriter writer;
        private readonly IReader reader;
        private readonly IController controller;

        public Engine(IWriter writer, IReader reader, IController controller)
        {
            this.writer = writer;
            this.reader = reader;
            this.controller = controller;
        }

        public void Run()
        {
            try
            {
                var name = reader.ReadLine();
                var age = int.Parse(reader.ReadLine());

                var chicken = controller.CreateChicken(name, age);

                writer.WriteLine(chicken);
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Name cannot be empty.");
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Age should be between 0 and 15.");
            }
        }
    }
}
