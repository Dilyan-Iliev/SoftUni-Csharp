using System;
using System.Collections.Generic;

namespace P._08_SoftUni_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> regularGuests = new HashSet<string>();
            HashSet<string> VIPGuests = new HashSet<string>();

            string input;
            while ((input = Console.ReadLine()) != "PARTY")
            {
                if (char.IsDigit(input[0]))
                {
                    VIPGuests.Add(input);
                }
                else
                {
                    regularGuests.Add(input);
                }
            }

            string removeInput;
            while ((removeInput = Console.ReadLine()) != "END")
            {
                if (VIPGuests.Contains(removeInput))
                {
                    VIPGuests.Remove(removeInput);
                }
                else if (regularGuests.Contains(removeInput))
                {
                    regularGuests.Remove(removeInput);
                }
            }
            Console.WriteLine(regularGuests.Count + VIPGuests.Count);
            foreach (var guest in VIPGuests)
            {
                Console.WriteLine(guest);
            }
            foreach (var guest in regularGuests)
            {
                Console.WriteLine(guest);
            }
        }
    }
}
