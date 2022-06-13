using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P._03_Telephony.Classes
{

    public class StationaryPhone : IDialable
    {
        private string phoneNumber;

        public StationaryPhone()
        {
        }
        public string PhoneNumber
        {
            get => phoneNumber;
            private set { phoneNumber = value; }
        }
        public void Dialling(string number)
        {
            if (number.Any(x => !char.IsDigit(x)))
            {
                throw new ArgumentException("Invalid number!");
            }

            Console.WriteLine($"Dialing... {number}");
        }
    }
}
