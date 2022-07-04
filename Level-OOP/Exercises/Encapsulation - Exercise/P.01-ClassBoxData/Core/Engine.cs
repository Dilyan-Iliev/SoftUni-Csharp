using PracticeForJudge.Core.Interfaces;
using PracticeForJudge.IO.Interfaces;

namespace PracticeForJudge.Core
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
            var length = double.Parse(reader.ReadLine());
            var width = double.Parse(reader.ReadLine());
            var height = double.Parse(reader.ReadLine());

            try
            {
                var box = controller.CreateBox(length, width, height);

                writer.WriteLine(box.ToString());

            }
            catch (System.ArgumentException ex)
            {
                writer.WriteLine(ex.Message);
            }
        }
    }
}
