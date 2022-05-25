using System;

namespace Person
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            if (age < 0)
            {
                return;
            }

            Person person = null;

            if (age <= 15)
            {
                person = new Child(age, name); //this is IS-A relation - child IS A person -> polymorphism
            }
            else
            {
                person = new Person(age, name);
            }
            
            Console.WriteLine(person.ToString());
        }
    }
}
