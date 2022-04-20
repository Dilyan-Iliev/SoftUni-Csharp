using System;
using System.Linq;
using System.Collections.Generic;

namespace P._05_Filter_By_Age
{
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    internal class Program
    {
        static void Main()
        {
            List<Person> people = new List<Person>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] personInfo = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = personInfo[0];
                int age = int.Parse(personInfo[1]);

                var person = new Person();
                person.Name = name;
                person.Age = age;

                people.Add(person);
            }
            string ageTypeFilter = Console.ReadLine();
            int ageFilter = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();

            Func<Person, bool> filter = p => true;
            if (ageTypeFilter == "younger")
            {
                filter = guy => guy.Age < ageFilter;
            }
            else if (ageTypeFilter == "older")
            {
                filter = guy => guy.Age >= ageFilter;
            }
            var filteredPeople = people.Where(filter); //ще изкара резултат на база горния филтър 

            Func<Person, string> printFunc = p => p.Name + " " + p.Age;
            if (format == "name age")
            {
                printFunc = p => $"{p.Name} - {p.Age}";
            }
            else if (format == "name")
            {
                printFunc = p => p.Name;
            }
            else if (format == "age")
            {
                printFunc = p => p.Age.ToString();
            }

            var personAsString = filteredPeople.Select(printFunc);

            foreach (var item in personAsString)
            {
                Console.WriteLine(item);
            }
        }

        //or other way to solve it:

        //static void Main(string[] args)
        //{
        //    int numberOfLines = int.Parse(Console.ReadLine());
        //    var dictionary = new Dictionary<string, int>();

        //    for (int i = 1; i <= numberOfLines; i++)
        //    {
        //        string[] input = Console.ReadLine()
        //            .Split(", ", StringSplitOptions.RemoveEmptyEntries);

        //        string name = input[0];
        //        int age = int.Parse(input[1]);

        //        if (!dictionary.ContainsKey(name))
        //        {
        //            dictionary[name] = age;
        //        }
        //    }

        //    string ageTypeFilter = Console.ReadLine();
        //    int ageFilter = int.Parse(Console.ReadLine());
        //    string format = Console.ReadLine();

        //    Func<int, bool> func = Function(ageTypeFilter, ageFilter);
        //    Action<KeyValuePair<string, int>> filter = Action(format);

        //    PrintResult(dictionary, func, filter);
        //}

        //static void PrintResult(Dictionary<string, int> dict, Func<int, bool> func,
        //    Action<KeyValuePair<string, int>> filter)
        //{
        //    foreach (var kvp in dict)
        //    {
        //        if (func(kvp.Value))
        //        {
        //            filter(kvp);
        //        }
        //    }
        //}

        //static Func<int, bool> Function(string condition, int age)
        //{
        //    switch (condition)
        //    {
        //        case "younger": return x => x < age;
        //        case "older": return x => x >= age;
        //        default: return null;
        //    }
        //}

        //static Action<KeyValuePair<string, int>> Action(string format)
        //{
        //    switch (format)
        //    {
        //        case "name": return x => Console.WriteLine(x.Key);
        //        case "age": return x => Console.WriteLine(x.Value);
        //        case "name age": return x => Console.WriteLine($"{x.Key} - {x.Value}");
        //        default: return null;
        //    }
        //}
    }
}
