using PersonsInfo.IO;
using System.Linq;

namespace PersonsInfo.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IController controller;

        public Engine(IReader reader, IWriter writer, IController controller)
        {
            this.reader = reader;
            this.writer = writer;
            this.controller = controller;
        }

        public void Run()
        {
            var team = controller.CreateTeam("SoftUni");

            var lines = int.Parse(reader.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                var tokens = reader.ReadLine()
                    .Split(' ', System.StringSplitOptions.RemoveEmptyEntries);

                string firstName = tokens[0];
                string lastName = tokens[1];
                int age = int.Parse(tokens[2]);
                decimal salary = decimal.Parse(tokens[3]);
                try
                {
                    var person = controller.CreatePerson(firstName, lastName, age, salary);
                    team.AddPlayer(person);

                }
                catch (System.ArgumentException ex)
                {
                    writer.WriteLine(ex.Message);
                }
            }

            writer.WriteLine(team.FirstTeam.Count);
            writer.WriteLine(team.SecondTeam.Count);
        }
    }
}
