using System;
using System.Linq;
using System.Collections.Generic;

namespace Man_O_War
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> pirateShipStatus = Console.ReadLine()
                .Split('>',StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            List<int> warShipStatus = Console.ReadLine()
                .Split('>', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int maxHealthOfASection = int.Parse(Console.ReadLine());

            string command;

            while ((command = Console.ReadLine()) != "Retire")
            {
                string[] cmdArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string currentCommand = cmdArgs[0];

                if (currentCommand == "Fire")
                {//the pirate ship attacks the warship with the given damage at that section
                    int index = int.Parse(cmdArgs[1]);
                    int dmg = int.Parse(cmdArgs[2]);

                    if(index >= 0 && index < warShipStatus.Count)//Check if the index is valid and if not, skip the command
                    {
                        if (warShipStatus[index] - dmg <= 0)//If the section breaks (health <= 0) the warship sinks
                        {//print the following and stop the program: 
                            Console.WriteLine("You won! The enemy ship has sunken.");
                            return;
                        }
                        else
                        {
                            warShipStatus[index] -= dmg;
                        }
                    }
                }
                else if (currentCommand == "Defend")
                {//the warship attacks the pirate ship with the given damage at that range (indexes are inclusive)
                    int startIndex = int.Parse(cmdArgs[1]);
                    int endIndex = int.Parse(cmdArgs[2]);
                    int dmg = int.Parse(cmdArgs[3]);

                    if (startIndex >= 0 && endIndex < pirateShipStatus.Count)
                    {
                        for (int i = startIndex; i <= endIndex; i++)
                        {
                            pirateShipStatus[i] -= dmg;
                            if(pirateShipStatus[i] <= 0)
                            {
                                Console.WriteLine("You lost! The pirate ship has sunken.");
                                return;
                            }
                        }
                    }
                }
                else if (currentCommand == "Repair")
                {//the crew repairs a section of the pirate ship with the given health
                    int index = int.Parse(cmdArgs[1]);
                    int health = int.Parse(cmdArgs[2]);

                    if(index >= 0 && index < pirateShipStatus.Count)
                    {
                        if (pirateShipStatus[index] + health <= maxHealthOfASection)
                        {
                            pirateShipStatus[index] += health;
                        }
                        else
                        {
                            pirateShipStatus[index] = maxHealthOfASection;
                        }
                    }
                }
                else if (currentCommand == "Status")
                {
                    int counter = 0;
                    double percent = maxHealthOfASection * 0.2;
                    for (int i = 0; i < pirateShipStatus.Count; i++)
                    {
                        if(pirateShipStatus[i] < percent)
                        {
                            counter++;
                        }
                    }
                    Console.WriteLine($"{counter} sections need repair.");
                }
            }
            int sum1 = pirateShipStatus.Sum();
            int sum2 = warShipStatus.Sum();
            Console.WriteLine($"Pirate ship status: {sum1}");
            Console.WriteLine($"Warship status: {sum2}");
        }
    }
}
