using P._06_Food_Shortage.Classes;
using P._06_Food_Shortage.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace P._06_Food_Shortage
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int numberOfPeople = int.Parse(Console.ReadLine());
            Town town = new Town();

            for (int i = 1; i <= numberOfPeople; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);


                string name = input[0];
                int age = int.Parse(input[1]);

                if (input.Length == 4)
                {
                    string id = input[2];
                    string birthdate = input[3];

                    Citizen citizen = new Citizen(name, age, id, birthdate);
                    town.AddCitizen(citizen);

                }
                else if (input.Length == 3)
                {
                    string group = input[2];

                    Rebel rebel = new Rebel(name, age, group);
                    town.AddRebel(rebel);
                }
            }

            int totalFood = 0;

            string nameInput;
            while ((nameInput = Console.ReadLine()) != "End")
            {
                if (town.Rebels.Any(x => x.Name == nameInput))
                {
                    Rebel rebel = town.Rebels.First(x => x.Name == nameInput);
                    totalFood += rebel.BuyFood();
                }

                else if(town.Citizens.Any(x => x.Name == nameInput))
                {
                    Citizen citizen = town.Citizens.First(x => x.Name == nameInput);
                    totalFood += citizen.BuyFood();
                }
            }

            Console.WriteLine(totalFood);
        }
    }
}
