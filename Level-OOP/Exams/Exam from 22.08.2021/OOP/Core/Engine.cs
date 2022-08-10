namespace SpaceStation.Core
{
    using System;
    using System.Linq;

    using IO;
    using Contracts;
    using IO.Contracts;

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
            while (true)
            {
                var input = reader.ReadLine().Split();
                if (input[0] == "Exit")
                {
                    Environment.Exit(0);
                }
                try
                {
                    string result = null;

                    if (input[0] == "AddAstronaut")
                    {
                        string astronautType = input[1];
                        string astronautName = input[2];

                        result = this.controller.AddAstronaut(astronautType, astronautName);
                    }
                    else if (input[0] == "AddPlanet")
                    {
                        string planetName = input[1];
                        string[] items = input
                            .Skip(2)
                            .ToArray();

                        result = this.controller.AddPlanet(planetName, items);
                    }
                    else if (input[0] == "RetireAstronaut")
                    {
                        string astronautName = input[1];

                        result = this.controller.RetireAstronaut(astronautName);
                    }
                    else if (input[0] == "ExplorePlanet")
                    {
                        string planetName = input[1];

                        result = this.controller.ExplorePlanet(planetName);
                    }
                    else if (input[0] == "Report")
                    {
                        result = this.controller.Report();
                    }

                    this.writer.WriteLine(result);
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                }
            }
        }
    }
}
