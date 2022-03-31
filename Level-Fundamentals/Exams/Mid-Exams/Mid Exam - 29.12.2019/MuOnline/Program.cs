using System;
using System.Linq;
using System.Collections.Generic;

namespace MuOnline
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] arr = Console.ReadLine()
                .Split('|', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            int playerHealth = 100;
            int amountOfBitcoins = 0;
            //bool isDead = false;
            int roomCounter = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                string currentSection = arr[i];
                string[] currentSectionArgs = currentSection.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string currentGameAction = currentSectionArgs[0];

                if (currentGameAction == "potion")
                {
                    int amountOfHeal = int.Parse(currentSectionArgs[1]);
                    roomCounter++;
                    if (playerHealth + amountOfHeal > 100)
                    {
                        Console.WriteLine($"You healed for {100-playerHealth} hp.");
                        playerHealth = 100;
                        Console.WriteLine($"Current health: {playerHealth} hp.");
                    }
                    else
                    {
                        playerHealth += amountOfHeal;
                        Console.WriteLine($"You healed for {amountOfHeal} hp.");
                        Console.WriteLine($"Current health: {playerHealth} hp.");
                    }
                }
                else if (currentGameAction == "chest")
                {
                    int bitcoinsFound = int.Parse(currentSectionArgs[1]);
                    Console.WriteLine($"You found {bitcoinsFound} bitcoins.");
                    amountOfBitcoins += bitcoinsFound;
                    roomCounter++;
                }
                else
                {
                    string currentMonster = currentSectionArgs[0];
                    int monsterAttackPower = int.Parse(currentSectionArgs[1]);
                    roomCounter++;

                    if (playerHealth - monsterAttackPower > 0)
                    {
                        playerHealth-= monsterAttackPower;
                        Console.WriteLine($"You slayed {currentMonster}.");
                    }
                    else if (playerHealth - monsterAttackPower <= 0)
                    {
                        Console.WriteLine($"You died! Killed by {currentMonster}.");
                        Console.WriteLine($"Best room: {roomCounter}");
                        //isDead = true;
                        return;
                    }
                }
            }
            Console.WriteLine("You've made it!");
            Console.WriteLine($"Bitcoins: {amountOfBitcoins}");
            Console.WriteLine($"Health: {playerHealth}");
        }
    }
}
