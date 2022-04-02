using System;
using System.Linq;
using System.Collections.Generic;

namespace Moving_Target
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);


                targets = ListCommands(targets, cmdArgs);
            }
            Console.WriteLine(String.Join("|", targets));
        }

        static List<int> ListCommands(List<int> list, string[] cmdArgs)
        {
            string currentCommand = cmdArgs[0];

            switch (currentCommand)
            {
                case "Shoot": list = CommandShoot(list, cmdArgs); break;
                case "Add": list = CommandAdd(list, cmdArgs); break;
                case "Strike": list = CommandStrike(list, cmdArgs); break;
            }

            return list;
        }

        static List<int> CommandShoot(List<int> list, string[] cmdArgs)
        {
            int index = int.Parse(cmdArgs[1]);
            int value = int.Parse(cmdArgs[2]);

            //- Shoot the target at the index if it exists by reducing its value by the given power (integer value). 
            //- Remove the target if it is shot. A target is considered shot when its value reaches 0.

            if (index >= 0 && index < list.Count)
            {
                if (list[index] - value > 0)
                {
                    list[index] = list[index] - value;
                }
                else if (list[index] - value <= 0)
                {
                    list.RemoveAt(index);
                }
            }

            return list;
        }

        static List<int> CommandAdd(List<int> list, string[] cmdArgs)
        {
            int index = int.Parse(cmdArgs[1]);
            int value = int.Parse(cmdArgs[2]); //check later if i have to switch this 

            //Insert a target with the received value at the received index if it exists. 
            //If not, print: "Invalid placement!"

            if (index >= 0 && index < list.Count)
            {
                list.Insert(index, value);
            }
            else
            {
                Console.WriteLine("Invalid placement!");
            }

            return list;
        }

        static List<int> CommandStrike(List<int> list, string[] cmdArgs)
        {
            int index = int.Parse(cmdArgs[1]);
            int radius = int.Parse(cmdArgs[2]);


            //Remove the target at the given index and the ones before and after it depending on the radius.
            //If any of the indices in the range is invalid, print: "Strike missed!" and skip this command

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == list[index])
                {
                    if (index - radius >= 0 && index + radius < list.Count)
                    {
                        list.RemoveRange(index - radius, radius * 2 + 1);
                    }
                    else
                    {
                        Console.WriteLine("Strike missed!");
                    }
                }
            }
            return list;
        }
    }
}
