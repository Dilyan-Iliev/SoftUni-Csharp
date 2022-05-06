using System;
using System.Collections.Generic;
using System.Linq;

namespace P._05_Generic_Count_Method_String
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int numberOfLines = int.Parse(Console.ReadLine());
            var list = new List<Box<string>>();

            for (int i = 0; i < numberOfLines; i++)
            {
                string element = Console.ReadLine();
                Box<string> box = new Box<string>();
                box.Element = element;

                list.Add(box);
            }

            string elementForComparison = Console.ReadLine();
            Console.WriteLine(CompareElements(list, elementForComparison));
        }

        static int CompareElements<T>(List<Box<T>> list, T elementForComparison)
            where T : IComparable<T>
        {
            var filteredList = list
                .Where(x => x.Compare(elementForComparison) > 0);

            return filteredList.Count();

            //int counter = 0;
            //foreach (var element in list)
            //{
            //    if (element.Compare(elementForComparison) > 0)
            //    {
            //        counter++;
            //    }
            //}
            //return counter;
           
        }
    }
}
