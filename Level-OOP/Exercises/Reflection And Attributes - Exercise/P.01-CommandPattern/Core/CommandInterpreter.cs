namespace CommandPattern.Core
{
    using System;
    using System.Linq;
    using System.Reflection;
    using CommandPattern.Core.Contracts;

    public class CommandInterpreter : ICommandInterpreter
    {  
        public string Read(string args)
        {
            string[] cmdArgs = args.Split(' ');
            string cmdName = cmdArgs[0] + "Command";
            string[] parameters = cmdArgs.Skip(1).ToArray();

            ICommand command = null;

            if (cmdName == nameof(HelloCommand))
            {
                command = new HelloCommand();
            }
            else if (cmdName == nameof(ExitCommand))
            {
                command = new ExitCommand();
            }
            else
            {
                throw new ArgumentException("Invalid command!");
            }
            string result = command.Execute(parameters);
            return result;

            //--------------------------------------------------

            //or with reflection :

            //string[] cmdArgs = args.Split(' ');
            //string cmdName = cmdArgs[0] + "Command";

            //Assembly currentAssembly = Assembly.GetCallingAssembly();
            //Type type = currentAssembly.GetTypes()
            //    .FirstOrDefault(x => x.Name == cmdName);

            //if (type == null)
            //{
            //    throw new ArgumentException("Invalid command!");
            //}

            //var commandType = Activator.CreateInstance(currentAssembly) as ICommand;
            //string result = commandType.Execute(cmdArgs);
            //return result;
        }
    }
}
