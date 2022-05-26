using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            string input;
            while ((input = Console.ReadLine()) != "Beast!")
            {
                string[] tokens = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string name = tokens[0];
                int age = int.Parse(tokens[1]);
                string gender = tokens[2];

                if (input == "Cat")
                {
                    Cat cat = new Cat(name, age, gender);
                    animals.Add(cat);
                }
                else if (input == "Dog")
                {
                    Dog dog = new Dog(name, age, gender);
                    animals.Add(dog);
                }
                else if (input == "Frog")
                {
                    Frog frog = new Frog(name, age, gender);
                    animals.Add(frog);
                }
                else if (input == "Kitten")
                {
                    Kitten kitten = new Kitten(name, age);
                    animals.Add(kitten);
                }
                else if (input == "Tomcat")
                {
                    Tomcat tomcat = new Tomcat(name, age);
                    animals.Add(tomcat);
                }
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal.GetType().Name);
                Console.WriteLine(animal.ToString());
                Console.WriteLine(animal.ProduceSound());
            }
        }
    }
}

