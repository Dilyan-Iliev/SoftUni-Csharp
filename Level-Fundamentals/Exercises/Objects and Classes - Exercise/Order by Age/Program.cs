using System;
using System.Collections.Generic;
using System.Linq;

namespace Order_by_Age
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<People> peopleData = new List<People>();
            while (true)
            {
                string[] arr = Console.ReadLine()
                    .Split()
                    .ToArray();

                if (arr[0] == "End")
                {
                    break;
                }

                string name = arr[0];
                string id = arr[1];
                int age = int.Parse(arr[2]);

                var person = new People(name, id, age);

                peopleData.Add(person);
            }
            List<People> orderedData = peopleData.OrderBy(person => person.Age).ToList();

            Console.WriteLine(string.Join(Environment.NewLine, orderedData));
        }
    }

    class People
    {
        public People(string name, string id, int age)
        {
            this.Name = name;
            this.ID = id;
            this.Age = age;
        }
        public string Name { get; set; }
        public string ID { get; set; }
        public int Age { get; set; }
        public override string ToString()
        {
            return $"{Name} with ID: {ID} is {Age} years old.";
        }

    }
}
