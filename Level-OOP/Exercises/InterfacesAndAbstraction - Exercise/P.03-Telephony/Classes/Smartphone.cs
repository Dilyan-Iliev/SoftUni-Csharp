using System;
using System.Collections.Generic;
using P._03_Telephony.Interfaces;
using System.Linq;

namespace P._03_Telephony.Classes
{
    public class Smartphone : ICallable, IBrowsable
    {
        private string phoneNumber;
        private string url;

        public Smartphone()
        {
        }

        public string PhoneNumber
        {
            get => phoneNumber;
            private set { phoneNumber = value; }
        }
        public string URL
        {
            get => url;
            private set { url = value; }
        }

        public void Browse(string URL)
        {
            if (URL.Any(x => char.IsDigit(x)))
            {
                throw new ArgumentException("Invalid URL!");
            }

            Console.WriteLine($"Browsing: {URL}!");
        }

        public void Call(string number)
        {
            if (number.Any(x => !char.IsDigit(x)))
            {
                throw new ArgumentException("Invalid number!");
            }

            Console.WriteLine($"Calling... {number}");
        }
    }
}
