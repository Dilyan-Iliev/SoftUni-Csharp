using System;
using System.Linq;
using System.Collections.Generic;

namespace P._08_Ranking
{
    internal class Program
    {
        //static void Main(string[] args)
        //{
        //    var passwordsDictionary = new Dictionary<string, string>();

        //    string validatePassword;
        //    while ((validatePassword = Console.ReadLine()) != "end of contests")
        //    {
        //        string[] inputArgs = validatePassword
        //            .Split(':', StringSplitOptions.RemoveEmptyEntries);

        //        string contest = inputArgs[0];
        //        string password = inputArgs[1];

        //        if (!passwordsDictionary.ContainsKey(contest))
        //        {
        //            passwordsDictionary.Add(contest, password);
        //        }
        //    }

        //    var candidatesDictionary = new Dictionary<string, Dictionary<string, int>>();

        //    string validateContest;
        //    while ((validateContest = Console.ReadLine()) != "end of submissions")
        //    {
        //        string[] inputArgs = validateContest
        //            .Split("=>", StringSplitOptions.RemoveEmptyEntries);

        //        string contest = (inputArgs[0]);
        //        string password = (inputArgs[1]);
        //        string username = (inputArgs[2]);
        //        int points = int.Parse(inputArgs[3]);

        //        if (passwordsDictionary.ContainsKey(contest)
        //            && passwordsDictionary[contest] == password)
        //        {
        //            if (!candidatesDictionary.ContainsKey(username))
        //            {
        //                candidatesDictionary.Add(username, new Dictionary<string, int>());
        //                //example - Tanya(main key) -> (C# funds (key) -> 350(value)) - value 

        //            }

        //            if (candidatesDictionary[username].ContainsKey(contest))
        //            {
        //                if (candidatesDictionary[username][contest] < points)
        //                {
        //                    candidatesDictionary[username][contest] = points;
        //                }
        //            }
        //            else
        //            {
        //                candidatesDictionary[username].Add(contest, points);
        //            }
        //        }
        //    }

        //    var bestUser = candidatesDictionary
        //        .OrderByDescending(x => x.Value.Values.Sum())
        //        .First().Key;

        //    var bestPoints = candidatesDictionary.OrderByDescending(x => x.Value.Values.Sum())
        //        .First()
        //        .Value.Values.Sum();

        //    Console.WriteLine($"Best candidate is {bestUser} with total {bestPoints} points.");

        //    Console.WriteLine("Ranking:");
        //    foreach (var student in candidatesDictionary.OrderBy(x=> x.Key))
        //    {
        //        Console.WriteLine(student.Key);
        //        foreach (var contest in student.Value
        //            .OrderByDescending(x => x.Value))
        //        {
        //            Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
        //        }
        //    }
        //    //or

        //    //foreach (var (key, value) in candidatesDictionary.OrderBy(x => x.Key))
        //    //{
        //    //    Console.WriteLine(key);

        //    //    foreach (var (contest, points) in value.OrderByDescending(x => x.Value))
        //    //    {
        //    //        Console.WriteLine($"#  {contest} -> {points}");
        //    //    }
        //    //}
        //}

        static void Main()
        {
            var passwordDictionary = new Dictionary<string, string>();
            var studentsDictionary = new Dictionary<string, Student>();

            string passwordValidation;
            while ((passwordValidation = Console.ReadLine()) != "end of contests")
            {
                string[] inputArgs = passwordValidation
                    .Split(':', StringSplitOptions.RemoveEmptyEntries);

                string contest = inputArgs[0];
                string password = inputArgs[1];

                if (!passwordDictionary.ContainsKey(contest))
                {
                    passwordDictionary.Add(contest, password);
                }
            }

            string contestValidation;
            while ((contestValidation = Console.ReadLine()) != "end of submissions")
            {
                string[] inputArgs = contestValidation
                    .Split("=>", StringSplitOptions.RemoveEmptyEntries);

                string contest = inputArgs[0];
                string password = inputArgs[1];
                string username = inputArgs[2];
                int points = int.Parse(inputArgs[3]);

                if (passwordDictionary.ContainsKey(contest)
                    && passwordDictionary[contest] == password)
                {
                    if (!studentsDictionary.ContainsKey(username))
                    {
                        var student = new Student(username);
                        studentsDictionary.Add(username, student);
                    }
                    var studentObj = studentsDictionary[username];

                    if (!studentObj.ContestsAndPoints.ContainsKey(contest))
                    {
                        studentObj.ContestsAndPoints.Add(contest, points);
                    }

                    if (studentObj.ContestsAndPoints[contest] < points)
                    {
                        studentObj.ContestsAndPoints[contest] = points;
                    }
                }
            }

            var bestStudent = studentsDictionary
                            .OrderByDescending(x => x.Value.ContestsAndPoints.Values.Sum())
                            .First().Key;

            var bestPoints = studentsDictionary.OrderByDescending(x => x.Value.ContestsAndPoints.Values.Sum())
                            .First().Value.ContestsAndPoints.Values.Sum();

            Console.WriteLine($"Best candidate is {bestStudent} with total {bestPoints} points.");

            Console.WriteLine("Ranking:");
            foreach (var item in studentsDictionary
                .OrderBy(x => x.Key))
            {
                Console.WriteLine(item.Key);
                foreach (var item2 in item.Value.ContestsAndPoints
                    .OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {item2.Key} -> {item2.Value}");
                }
            }
        }
    }

    class Student
    {
        public Student(string name)
        {
            this.Name = name;
            ContestsAndPoints = new Dictionary<string, int>();
        }
        public string Name { get; set; }
        public Dictionary<string, int> ContestsAndPoints { get; set; }
    }
}
