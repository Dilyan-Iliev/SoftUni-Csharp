using Abstract_Classes;
using System;
using System.Collections.Generic;
using WildFarm.Entities;

namespace WildFarm
{
    public class StartUp
    {
        static void Main()
        {
            List<Animal> animals = new List<Animal>();
            Animal animal = null;
            Food food = null;
            int lineCounter = 0;
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                try
                {
                    var tokens = input
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    string type = tokens[0];

                    if (lineCounter % 2 == 0)
                    {
                        BuildAnimal(tokens, type, ref animal);
                        animals.Add(animal);
                        Console.WriteLine(animal.AskForFood());
                        lineCounter++;
                        continue;
                    }
                    else
                    {
                        BuildFood(tokens, type, ref food);
                    }


                    lineCounter++;
                    animal.Eat(food);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            foreach (var item in animals)
            {
                Console.WriteLine(item.ToString());
            }
        }

        static void BuildFood(string[] tokens, string type, ref Food food)
        {
            int foodQuantity = int.Parse(tokens[1]);
            switch (type)
            {
                case "Vegetable":
                    food = new Vegetable(foodQuantity);
                    break;
                case "Fruit":
                    food = new Fruit(foodQuantity);
                    break;
                case "Meat":
                    food = new Meat(foodQuantity);
                    break;
                case "Seeds":
                    food = new Seeds(foodQuantity);
                    break;
                default:
                    break;
            }
        }

        static void BuildAnimal(string[] tokens, string type, ref Animal animal)
        {
            string name = tokens[1];
            double weight = double.Parse(tokens[2]);
            switch (type)
            {
                case "Cat":
                    string catLivingRegion = tokens[3];
                    string catBreed = tokens[4];
                    animal = new Cat(name, weight, catLivingRegion, catBreed);
                    break;
                case "Tiger":
                    string tigerLivingRegion = tokens[3];
                    string tigerBreed = tokens[4];
                    animal = new Tiger(name, weight, tigerLivingRegion, tigerBreed);
                    break;
                case "Dog":
                    string dogLivingRegion = tokens[3];
                    animal = new Dog(name, weight, dogLivingRegion);
                    break;
                case "Mouse":
                    string mouseLivingRegion = tokens[3];
                    animal = new Mouse(name, weight, mouseLivingRegion);
                    break;
                case "Owl":
                    double owlWingSize = double.Parse(tokens[3]);
                    animal = new Owl(name, weight, owlWingSize);
                    break;
                case "Hem":
                    double hemWingSize = double.Parse(tokens[3]);
                    animal = new Hem(name, weight, hemWingSize);
                    break;
                default:
                    break;
            }
        }
    }
}
