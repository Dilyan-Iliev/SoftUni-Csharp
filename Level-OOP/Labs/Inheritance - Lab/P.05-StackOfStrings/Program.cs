using System;
using System.Collections.Generic;

namespace P._05_StackOfStrings
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            StackOfStrings stackOfStrings = new StackOfStrings();
            Console.WriteLine(stackOfStrings.IsEmpty());
            List<string> argsList = new List<string>();
            argsList.Add("1");
            argsList.Add("2");
            argsList.Add("3");
            stackOfStrings.AddRange(argsList);
            Console.WriteLine(stackOfStrings.IsEmpty());

        }
    }
}
