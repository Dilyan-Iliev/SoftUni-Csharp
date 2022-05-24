using System;

namespace P._04_RandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList list = new RandomList();
            list.Add("1");
            list.Add("2");
            list.Add("3");
            list.Add("4");

            Console.WriteLine(list.RandomString());
            Console.WriteLine(list.RemoveElement());
        }
    }
}
