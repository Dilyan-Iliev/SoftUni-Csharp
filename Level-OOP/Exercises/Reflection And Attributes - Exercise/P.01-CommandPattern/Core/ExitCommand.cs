namespace CommandPattern.Core
{
    using CommandPattern.Core.Contracts;

    public class ExitCommand : ICommand
    {
        public string Execute(string[] args)
         => null; //should exit programm
    }
}
