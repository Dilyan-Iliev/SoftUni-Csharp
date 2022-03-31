using System;

namespace Activation_Keys
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string rawActivationKey = Console.ReadLine();

            string command;
            while ((command = Console.ReadLine()) != "Generate")
            {
                string[] cmdArgs = command
                    .Split(">>>", StringSplitOptions.RemoveEmptyEntries);

                StringOperations(ref rawActivationKey, cmdArgs);
            }
            Console.WriteLine($"Your activation key is: {rawActivationKey}");
        }

        static string StringOperations (ref string rawActivationKey, string[] arr)
        {
            string cmd = arr[0];

            switch (cmd)
            {
                case "Contains": ContainsOperation(ref rawActivationKey, arr); break;
                case "Flip": FlipOperation(ref rawActivationKey, arr); break;
                case "Slice": SliceOperation(ref rawActivationKey, arr); break;
            }

            return rawActivationKey;
        }

        static string ContainsOperation (ref string rawActivationKey, string[] arr)
        {
            string substring = arr[1];

            if (!rawActivationKey.Contains(substring))
            {
                Console.WriteLine("Substring not found!");
            }
            else
            {
                Console.WriteLine($"{rawActivationKey} contains {substring}");
            }

            return rawActivationKey;
        }

        static string FlipOperation (ref string rawActivationKey, string[] arr)
        {
            string filter = arr[1];
            int startIndex = int.Parse(arr[2]);
            int endIndex = int.Parse(arr[3]);

            string substring = rawActivationKey.Substring(startIndex, endIndex - startIndex);
            if (filter == "Upper")
            {
                substring = substring.ToUpper();
            }
            else if (filter == "Lower")
            {
                substring = substring.ToLower();
            }

            rawActivationKey = rawActivationKey.Remove(startIndex, endIndex-startIndex);
            rawActivationKey = rawActivationKey.Insert(startIndex, substring);

            Console.WriteLine(rawActivationKey);

            return rawActivationKey;
        }

        static string SliceOperation (ref string rawActivationKey, string[] arr)
        {
            int startIndex = int.Parse(arr[1]);
            int endIndex = int.Parse(arr[2]);

            rawActivationKey = rawActivationKey.Remove(startIndex, endIndex-startIndex);

            Console.WriteLine(rawActivationKey);

            return rawActivationKey;
        }
    }
}
