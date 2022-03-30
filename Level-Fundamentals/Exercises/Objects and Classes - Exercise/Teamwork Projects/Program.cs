using System;
using System.Linq;
using System.Collections.Generic;

namespace Teamwork_Projects
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfTeams = int.Parse(Console.ReadLine());
            List<Team> teams = new List<Team>();

            //RegisterTeams(teams, numberOfTeams);
            //or
            for (int i = 1; i <= numberOfTeams; i++)
            {
                string[] teamArgs = Console.ReadLine()
                    .Split('-', StringSplitOptions.RemoveEmptyEntries);

                string teamCreator = teamArgs[0];
                string teamName = teamArgs[1];

                //First iteration always false
                if (teams.Any(t => t.Name == teamName)) //.Any returns true/false в зависимост дали поне 1 елемент отговаря на условието
                {//има ли някой отбор със същото име,т.е. дали някой отбор отговаря на зададеното условие

                    //There is duplicate team if return true;
                    Console.WriteLine($"Team {teamName} was already created!");
                    continue;
                }

                //First iteration always false
                if (teams.Any(t => t.Creator == teamCreator))
                {
                    Console.WriteLine($"{teamCreator} cannot create another team!");
                    continue;
                }

                Team newTeam = new Team(teamName, teamCreator);
                teams.Add(newTeam);
                Console.WriteLine($"Team {teamName} has been created by {teamCreator}!");
            }

            string command;
            while ((command = Console.ReadLine()) != "end of assignment")
            {
                string[] joinArgs = command
                    .Split("->", StringSplitOptions.RemoveEmptyEntries);

                string memberName = joinArgs[0];
                string teamName = joinArgs[1];

                Team searchedTeam = teams //правя нов обект 
                    .FirstOrDefault(t => t.Name == teamName);//връша 1я item/обект от горния списък, който отговаря на даденото условие, а ако не намери никой с такова име, ще запише default-ната стойност в променливата team, която е null

                if (searchedTeam == null)//ако в горната променлива се е върнала null, т.е. няма отбор с такова име
                {
                    Console.WriteLine($"Team {teamName} does not exist!");
                    continue;
                }

                //LINQ equivalent of the below if 
                //if (teams.Any(t => t.Members.Contains(memberName)))
                //{//има ли някой отбор, който отогваря на това условие - да се съдържа даденото име на член
                //    Console.WriteLine($"Member {memberName} cannot join team {teamName}!");
                //    continue;
                //}
                //or
                if (IsAlreadyMemberOfTeam(teams, memberName))
                {
                    Console.WriteLine($"Member {memberName} cannot join team {teamName}!");
                    continue;
                }

                if (teams.Any(t => t.Creator == memberName))
                {//има ли в отборите някой отбор, в който името на създаделя е същото като на този, който се опитва да се присъедини
                    //Creator of a team cannot be a member of another team
                    Console.WriteLine($"Member {memberName} cannot join team {teamName}!");
                    continue;
                }

                searchedTeam.AddMember(memberName);//на обекта searchedTeam му извиквам метода AddMember
            }

            List<Team> teamsWithMembers = teams
                .Where(t => t.Members.Count > 0)//филтър за да взема тези обекти, които отговарят на даденото условие - т.е. списъкът с членове е > 0
                .OrderByDescending(t => t.Members.Count)//подреди ги по броя неща
                .ThenBy(t => t.Name) //по тяхното име азбучно
                .ToList();

            List<Team> teamsToDisband = teams
                .Where(t => t.Members.Count == 0)
                .OrderBy(t => t.Name)
                .ToList();

            PrintValidTeams(teamsWithMembers);

            PrintInvalidTeams(teamsToDisband);
        }
        /// <summary>
        /// Checks whether the provided member name exists in members of teams
        /// </summary>
        static bool IsAlreadyMemberOfTeam(List<Team> teams, string memberName)
        {
            foreach (Team team in teams)
            {
                if (team.Members.Contains(memberName))//ако в сегашния team списък от members дали садържа даденото име
                {
                    return true;
                }
            }
            return false;
        }
        static void PrintValidTeams(List<Team> validTeams)
        {
            foreach (Team validTeam in validTeams)
            {
                Console.WriteLine($"{validTeam.Name}");
                Console.WriteLine($"- {validTeam.Creator}");

                foreach (string currentMember in validTeam.Members.OrderBy(m => m))//подреждам ги по себе си
                {
                    Console.WriteLine($"-- {currentMember}");
                }
            }
        }
        static void PrintInvalidTeams(List<Team> invalidTeams)
        {
            Console.WriteLine("Teams to disband:");
            foreach (Team invalidTeam in invalidTeams)
            {
                Console.WriteLine($"{invalidTeam.Name}");
            }
        }

        //static void RegisterTeams(List<Team> teams, int n)
        //{
        //    for (int i = 1; i <= n; i++)
        //    {
        //        string[] teamArgs = Console.ReadLine()
        //            .Split('-', StringSplitOptions.RemoveEmptyEntries);

        //        string teamCreator = teamArgs[0];
        //        string teamName = teamArgs[1];

        //        if (teams.Any(t => t.Name == teamName)) //.Any returns true/false в зависимост дали поне 1 елемент отговаря на условието
        //        {//има ли някой отбор със същото име,т.е. дали някой отбор отговаря на зададеното условие

        //            //There is duplicate team if return true;
        //            Console.WriteLine($"Team {teamName} was already created!");
        //            continue;
        //        }
        //        if (teams.Any(t => t.Creator == teamCreator))
        //        {
        //            Console.WriteLine($"{teamCreator} cannot create another team!");
        //            continue;
        //        }

        //        Team newTeam = new Team(teamName, teamCreator);
        //        teams.Add(newTeam);
        //        Console.WriteLine($"Team {teamName} has been created by {teamCreator}");
        //    }
        //}
    }

    class Team
    {
        public Team(string teamName, string creatorName)
        {
            this.Name = teamName;
            this.Creator = creatorName;

            //Always initialize collecttions in the ctor!!!
            this.Members = new List<string>();
        }
        public string Name { get; set; }
        public string Creator { get; set; }
        public List<string> Members { get; set; }

        public void AddMember(string member)
        {
            //There may be some validations!
            this.Members.Add(member);
        }
    }
}
