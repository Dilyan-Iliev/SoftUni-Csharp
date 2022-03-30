using System;

namespace Substring
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string keyWordToRemove = Console.ReadLine().ToLower();
            string text = Console.ReadLine();

            while (text.Contains(keyWordToRemove))
            {
                var index = text.IndexOf(keyWordToRemove); //посочвам индекс, от който долу да започне премахването
                text = text.Remove(index, keyWordToRemove.Length); //задавам от кой индекс и с каква дължина да е премахването
            }
            Console.WriteLine(text);

            //or

            //while (text.Contains(keyWordToRemove))
            //{
            //    text = text.Replace(keyWordToRemove, "");
            //}
            //Console.WriteLine(text);
        }
    }
}
