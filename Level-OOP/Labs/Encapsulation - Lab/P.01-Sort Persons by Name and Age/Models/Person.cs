﻿namespace PracticeForJudge.Models
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
            private set { firstName = value; }
        }
        public string LastName
        {
            get => lastName;
            private set { lastName = value; }
        }
        public int Age
        {
            get => age;
            private set { age = value; }
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} is {Age} years old.";
        }
    }
}
