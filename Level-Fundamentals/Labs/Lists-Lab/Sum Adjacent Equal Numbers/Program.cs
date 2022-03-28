using System;
using System.Collections.Generic;
using System.Linq;

namespace Sum_Adjacent_Equal_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string values = Console.ReadLine();
            List<string> valuesAsStringList = values
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            List<double> valuesAsIntList = new List<double>();

            for (int i = 0; i < valuesAsStringList.Count; i++)
            {
                double value = double.Parse(valuesAsStringList[i]);
                valuesAsIntList.Add(value);
            }

            //or List<double> values = Console.ReadLine()
            //.Split(' ', StringSplitOptions.RemoveEmptyEntries)
            //.Select(double.Parse)
            //.ToList();

            for (int i = 0; i < valuesAsIntList.Count; i++)
            {
                if (valuesAsIntList[i] == valuesAsIntList[i + 1])
                {
                    valuesAsIntList[i] += valuesAsIntList[i + 1];
                    valuesAsIntList.RemoveAt(i+1);
                    i = 0;
                }
            }

        }
    }
}
