using System;

namespace P._03_Oldest_Family_Member
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var family = new Family();

            for (int i = 0; i < n; i++)
            {
                string[] people = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string name = people[0];
                int age = int.Parse(people[1]);

                var guy = new Person(name, age);

                family.AddMember(guy);

            }

            Console.WriteLine(family.GetOldestMember().ToString());
        }
    }
}
