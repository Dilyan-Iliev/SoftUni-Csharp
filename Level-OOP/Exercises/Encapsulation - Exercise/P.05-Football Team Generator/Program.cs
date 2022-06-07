using System;
using System.Collections.Generic;
using System.Linq;

namespace P._05_Football_Team_Generator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] tokens = input
                    .Split(';', StringSplitOptions.RemoveEmptyEntries);

                string command = tokens[0];
                string teamName = tokens[1];
                string playerName = default;

                switch (command)
                {
                    case "Add" when teams.Any(x => x.Name == teamName): //да се изпълни когато (when) е изпълнено даденото условие
                        playerName = tokens[2];
                        int endurance = int.Parse(tokens[3]);
                        int sprint = int.Parse(tokens[4]);
                        int dribble = int.Parse(tokens[5]);
                        int passing = int.Parse(tokens[6]);
                        int shooting = int.Parse(tokens[7]);

                        try
                        {
                            Player player = new Player(playerName, endurance, sprint, dribble, passing, shooting);
                            teams.First(x => x.Name == teamName).Add(player);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            continue;
                        }

                        break;

                    case "Remove" when teams.Any(x => x.Name == teamName):
                        try
                        {
                            playerName = tokens[2];
                            teams.First(x => x.Name == teamName)
                                .Remove(playerName);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            continue;
                        }

                        break;

                    case "Rating" when teams.Any(x => x.Name == teamName):
                        Team team = teams.First(x => x.Name == teamName);
                        Console.WriteLine(team.ToString());
                        break;

                    case "Team":
                        teams.Add(new Team(teamName));
                        break;

                    default:
                        Console.WriteLine($"Team {teamName} does not exist.");
                        break;
                }
            }
        }
    }
}
