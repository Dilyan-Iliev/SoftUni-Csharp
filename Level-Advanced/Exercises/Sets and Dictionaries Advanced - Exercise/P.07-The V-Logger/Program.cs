using System;
using System.Linq;
using System.Collections.Generic;

namespace P._07_The_V_Logger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var vLoger = new Dictionary<string, Dictionary<string, HashSet<string>>>();
            //name -> following/followers -> names

            string following = "following";
            string followers = "followers";

            string input;
            while ((input = Console.ReadLine()) != "Statistics")
            {
                string[] inputArgs = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string firstVloger = inputArgs[0];
                string action = inputArgs[1];
                string secondVloger = inputArgs[2];

                if (action == "joined")
                {
                    if (!vLoger.ContainsKey(firstVloger))
                    {
                        vLoger.Add(firstVloger, new Dictionary<string, HashSet<string>>());
                        //инициализирам стойност речник за всеки главен ключ на главния речник

                        vLoger[firstVloger].Add(following, new HashSet<string>());
                        vLoger[firstVloger].Add(followers, new HashSet<string>());
                        //инициализирам за всеки firstVloger ключ и нов хешСет от хора
                    }
                }
                else if (action == "followed" && vLoger.ContainsKey(firstVloger)
                    && vLoger.ContainsKey(secondVloger) && firstVloger != secondVloger
                    && !vLoger[secondVloger][followers].Contains(firstVloger))
                {
                    //If any of the given vlogernames does not exist in your collection, ignore that command

                    //Vlogger cannot follow himself

                    //Vloggers cannot follow someone he is already a follower of

                    vLoger[firstVloger][following].Add(secondVloger);//добавям хора които нашия влогър следва
                    vLoger[secondVloger][followers].Add(firstVloger);//добавям хора които следват нашия влогър 
                }
            }

            Console.WriteLine($"The V-Logger has a total of {vLoger.Count} vloggers in its logs.");

            var sortedDictionary = vLoger.OrderByDescending(x => x.Value[followers].Count)
                .ThenBy(x => x.Value[following].Count)
                .ToDictionary(x => x.Key, y => y.Value);

            int counter = 1;

            foreach (var currVloger in sortedDictionary)
            {
                Console.WriteLine($"{counter}. {currVloger.Key} : {currVloger.Value[followers].Count} followers, {currVloger.Value[following].Count} following");

                if (counter == 1)
                {
                    foreach (var item in currVloger.Value[followers]
                        .OrderBy(x => x))
                    {
                        Console.WriteLine($"*  {item}");
                    }
                }
                counter++;
            }
        }
    }
}

//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace SetsAndDictionaries
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            var vlogger = new Dictionary<string, Vlogger>();

//            string input = Console.ReadLine();

//            while (input != "Statistics")
//            {
//                string[] inputArgs = input.Split();

//                string action = inputArgs[1];
//                string user = inputArgs[0];
//                string starUser = inputArgs[2];

//                if (action == "joined" && !vlogger.ContainsKey(user))
//                {
//                    vlogger.Add(user, new Vlogger());
//                }
//                else if (action == "followed" && vlogger.ContainsKey(user)
//                    && vlogger.ContainsKey(starUser) && user != starUser)
//                {
//                    vlogger[user].Following.Add(starUser);
//                    vlogger[starUser].Followers.Add(user);
//                }

//                input = Console.ReadLine();
//            }

//            Console.WriteLine($"The V-Logger has a total of {vlogger.Count} vloggers in its logs.");

//            var sortedVloggers = vlogger.OrderByDescending(x => x.Value.Followers.Count)
//                .ThenBy(x => x.Value.Following.Count);

//            int counter = 1;

//            foreach (var currentVlogger in sortedVloggers)
//            {
//                Console.WriteLine($"{counter}. {currentVlogger.Key} : {currentVlogger.Value.Followers.Count} followers, {currentVlogger.Value.Following.Count} following");

//                if (counter == 1)
//                {
//                    foreach (var item in currentVlogger.Value.Following.OrderBy(x => x))
//                    {
//                        Console.WriteLine($"*  {item}");
//                    }
//                }

//                counter++;
//            }
//        }
//    }

//    public class Vlogger
//    {
//        public Vlogger()
//        {
//            this.Followers = new HashSet<string>();
//            this.Following = new HashSet<string>();
//        }

//        public HashSet<string> Followers { get; set; }

//        public HashSet<string> Following { get; set; }
//    }
//}