using System;
using System.Text;

namespace Password_Reset
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            string command;
            while ((command = Console.ReadLine()) != "Done")
            {
                string[] cmdArgs = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                StringManipulation(ref password, cmdArgs);
            }
            Console.WriteLine($"Your password is: {password}");
        }

        static string StringManipulation(ref string password, string[] arr)
        {
            string command = arr[0];

            switch (command)
            {
                case "TakeOdd": TakeOddCmd(ref password); break;
                case "Cut": CutCmd(ref password, arr); break;
                case "Substitute": SubstituteCmd(ref password, arr); break;
            }

            return password;
        }

        static string TakeOddCmd(ref string password)
        {
            var sb = new StringBuilder();

            for (int i = 1; i < password.Length; i += 2)
            {
                //start from 1 because 0 is always even, and itterate +2 to step always on odd index, in order to reduce itteration count
                if (i % 2 != 0)
                {
                    sb.Append(password[i]);
                }
            }
            password = sb.ToString();

            Console.WriteLine(password);
            return password;
        }

        static string CutCmd(ref string password, string[] arr)
        {
            int startIndex = int.Parse(arr[1]);
            int length = int.Parse(arr[2]);

            password = password.Remove(startIndex, length);

            Console.WriteLine(password);
            return password;
        }

        static string SubstituteCmd(ref string password, string[] arr)
        {
            string elementToReplace = arr[1];
            string elementToReplaceWith = arr[2];

            if (password.Contains(elementToReplace))
            {
                password = password.Replace(elementToReplace, elementToReplaceWith);
                Console.WriteLine(password);
            }
            else
            {
                Console.WriteLine("Nothing to replace!");
            }

            return password;
        }
    }
}
