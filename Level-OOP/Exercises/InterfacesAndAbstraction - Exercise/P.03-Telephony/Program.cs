using P._03_Telephony.Classes;
using P._03_Telephony.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace P._03_Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var phoneNumbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            var URLs = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            foreach (var number in phoneNumbers)
            {
                try
                {
                    if (number.Length == 7)
                    {
                        StationaryPhone stationaryPhone = new StationaryPhone();
                        stationaryPhone.Dialling(number);
                    }
                    else if (number.Length == 10)
                    {
                        Smartphone smartphone = new Smartphone();
                        smartphone.Call(number);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            foreach (var url in URLs)
            {
                try
                {
                    Smartphone smartphone = new Smartphone();
                    smartphone.Browse(url);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
