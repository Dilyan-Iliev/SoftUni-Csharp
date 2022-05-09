using System;
using System.Linq;

namespace P._01_ListyIterator
{
    public class Program
    {
        static void Main(string[] args)
        {
            ListyIterator<string> obj = null;

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] cmdArgs = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string currentCmd = cmdArgs[0];

                if (currentCmd == "Create")
                {
                    string[] elementsForTheObj = cmdArgs.Skip(1).ToArray();
                    obj = new ListyIterator<string>(elementsForTheObj);
                }
                else if (currentCmd == "Move")
                {
                    Console.WriteLine(obj.Move());
                }
                else if (currentCmd == "HasNext")
                {
                    Console.WriteLine(obj.HasNext());
                }
                else if (currentCmd == "Print")
                {
                    obj.Print();
                }
            }
        }
    }
}
