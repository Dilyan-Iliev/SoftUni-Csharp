namespace Shapes
{
    using _8.IO;
    using _8.Engine;
    using _8.IO.Interfaces;
    using _8.Engine.Interfaces;

    public class Program
    {
        static void Main(string[] args)
        {
            IWriter writer = new ConsoleWriter();
            IReader reader = new ConsoleReader();

            IEngine engine = new Engine(writer, reader);
            engine.Run();
        }
    }
}
