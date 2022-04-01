using System;
using System.Linq;
using System.Collections.Generic;

namespace Array_Modifier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string command;

            while ((command = Console.ReadLine()) != "end")
            {
                string[] cmdArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                numbers = ArrayCommands(numbers, cmdArgs);
            }
            Console.WriteLine(string.Join(", ", numbers));
        }

        static List<int> ArrayCommands(List<int> list, string[] cmdArgs)
        {
            string command = cmdArgs[0];

            switch (command)
            {
                case "swap": list = SwapCommand(list, cmdArgs); break;
                case "multiply":list = MultiplyCommand(list, cmdArgs); break;
                case "decrease": list = DecreaseCommand(list, cmdArgs); break;
            }

            return list;
        }

        static List<int> SwapCommand(List<int> list, string[] cmdArgs)
        {
            int index1 = int.Parse(cmdArgs[1]);
            int index2 = int.Parse(cmdArgs[2]);
            int currentValue = list[index1];
            list[index1] = list[index2];
            list[index2] = currentValue;

            return list;
        }

        static List<int> MultiplyCommand(List<int> list, string[] cmdArgs)
        {

            int firstIndex = int.Parse(cmdArgs[1]); // 2 [3] 4 1, т.е. индекс 1
            int secondIndex = int.Parse(cmdArgs[2]); // 2 3 [4] 1, т.е. индекс 2

            int result = list[firstIndex] * list[secondIndex]; // 3 * 4

            list[firstIndex] = result;

            
            return list;
        }

        static List<int> DecreaseCommand(List<int> list, string[] cmdArgs)
        {
            for (int i = 0; i < list.Count; i++)
            {
                list[i] -= 1;
            }
            return list;
        }
    }
}
