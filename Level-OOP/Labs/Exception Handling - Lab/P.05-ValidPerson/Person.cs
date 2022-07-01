using System;
using System.Collections.Generic;
using System.Text;

namespace P._05_ValidPerson
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private int age;

        public Person(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        public string FirstName
        { 
            get => firstName;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("value", "The first name cannot be null or empty");
                }

                foreach (var ch in value)
                {
                    if (char.IsDigit(ch) 
                        || char.IsSymbol(ch))
                    {
                        throw new InvalidPersoNameException("First name cannot contains special symbols");
                    }
                }

                this.firstName = value;
            }
        }
        public string LastName 
        { 
            get => lastName;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("value", "The last name cannot be null or empty");
                }

                foreach (var ch in value)
                {
                    if (char.IsDigit(ch)
                        || char.IsSymbol(ch))
                    {
                        throw new InvalidPersoNameException("Last name cannot contains special symbols");
                    }
                }

                this.lastName = value;
            }
        }
        public int Age 
        {
            get => age; 
            private set
            {
                if (value < 0 || value > 120)
                {
                    throw new ArgumentOutOfRangeException("value", "Age should be in range [0 .. 120]");
                }

                this.age = value;
            }
        }
    }
}
