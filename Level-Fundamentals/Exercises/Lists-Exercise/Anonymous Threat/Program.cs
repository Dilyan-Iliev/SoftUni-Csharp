using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Anonymous_Threat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine()
                .Split(' ',StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string command;
            while ((command = Console.ReadLine()) != "3:1")
            {
                string[] cmdArgs = command.Split();

                list = Commands(list, cmdArgs);
            }

            Console.WriteLine(String.Join(" ",list));
            
        }

        static List<string> Commands(List<string> values, string[] command)
        {
            string currentCommand = command[0];

            switch (currentCommand)
            {
                case "merge": values = MergeCmd(values, command); break;

                case "divide": values = DivideCmd(values, command); break;
            }

            return values;
        }

        static List<string> MergeCmd(List<string> values, string[] command)
        {
            int mergeStartIndex = int.Parse(command[1]);
            int mergeEndIndex = int.Parse(command[2]);
            //string concatElement = string.Empty;

            if (mergeStartIndex < 0 || mergeStartIndex > values.Count)
            {
                mergeStartIndex = 0;
                
            }
            if (mergeEndIndex > values.Count - 1 || mergeEndIndex < 0 )
            {
                mergeEndIndex = values.Count - 1;
            }

            StringBuilder sb = new StringBuilder();
            for (int i = mergeStartIndex; i <= mergeEndIndex; i++)
            {
                //or concatElement+=values[i];
                sb.Append(values[i]);
            }
            
            values.RemoveRange(mergeStartIndex, mergeEndIndex - mergeStartIndex + 1);
            values.Insert(mergeStartIndex, sb.ToString());

            return values;
        }

        static List<string> DivideCmd(List<string> values, string[] command)
        {

            List<string> dividedValues = new List<string>();
            int index = int.Parse(command[1]);
            int partitions = int.Parse(command[2]);

            string wordToDivide = values[index]; //this element must be divided
            values.RemoveAt(index);
            int parts = wordToDivide.Length / partitions;

            for (int i = 0; i < partitions; i++) //go through wordToDivide
            {              
                if (i == partitions - 1)
                {
                    dividedValues.Add(wordToDivide.Substring(i * parts));//(start index)
                }
                else
                {
                    dividedValues.Add(wordToDivide.Substring(i * parts, parts));//(start index, length)
                }
            }
            values.InsertRange(index, dividedValues);

            return values;
        }


    }
}
