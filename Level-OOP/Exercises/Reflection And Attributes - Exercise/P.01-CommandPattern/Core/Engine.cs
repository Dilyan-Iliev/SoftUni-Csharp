namespace CommandPattern.Core
{
    using System;
    using System.Linq;
    using CommandPattern.Core.Contracts;

    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            string input;
            while ((input = Console.ReadLine()) != "Exit")
            {
                try
                {
                    string text = commandInterpreter.Read(input);
                    Console.WriteLine(text);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
        }
    }
}
