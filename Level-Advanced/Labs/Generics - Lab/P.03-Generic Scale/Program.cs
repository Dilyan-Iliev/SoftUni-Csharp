using System;

namespace GenericScale
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var obj = new EqualityScale<string>("name1", "name2");
            Console.WriteLine(obj.AreEqual());

            var obj2 = new EqualityScale<int>(3, 3);
            Console.WriteLine(obj2.AreEqual());
        }
    }
}
