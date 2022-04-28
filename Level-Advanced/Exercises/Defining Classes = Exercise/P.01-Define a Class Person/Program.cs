using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var person = new Person();
            person.Name = "Peter";
            person.Age = 20;

            var secondPerson = new Person("George", 18);
        }
    }
}
