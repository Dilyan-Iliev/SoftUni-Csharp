using System;
using System.Collections.Generic;
using System.Linq;

namespace P._05_Football_Team_Generator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, Team> teams = new Dictionary<string, Team>();

            string command;

            while ((command = Console.ReadLine()) != "END")
            {
                string[] cmdArgs = command
                    .Split(';');

                string action = cmdArgs[0];

                try
                {
                    if (action == "Team")
                    {
                        string name = cmdArgs[1];

                        Team team = new Team(name);
                        teams.Add(name, team);
                    }
                    else if (action == "Add")
                    {
                        string teamName = cmdArgs[1];

                        if (!teams.ContainsKey(teamName))
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                            continue;
                        }

                        string playerName = cmdArgs[2];
                        int endurance = int.Parse(cmdArgs[3]);
                        int sprint = int.Parse(cmdArgs[4]);
                        int dribble = int.Parse(cmdArgs[5]);
                        int passing = int.Parse(cmdArgs[6]);
                        int shooting = int.Parse(cmdArgs[7]);

                        Player player = new Player(playerName, endurance, sprint, dribble, passing, shooting);

                        teams[teamName].AddPlayer(player);
                    }
                    else if (action == "Remove")
                    {
                        string teamName = cmdArgs[1];
                        string playerToRemove = cmdArgs[2];

                        teams[teamName].RemovePlayer(playerToRemove);
                    }
                    else if (action == "Rating")
                    {
                        string teamName = cmdArgs[1];

                        if (!teams.ContainsKey(teamName))
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                            continue;
                        }

                        Console.WriteLine($"{teamName} - {teams[teamName].Rating}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
