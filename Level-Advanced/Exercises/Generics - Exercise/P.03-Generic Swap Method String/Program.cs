using System;
using System.Collections.Generic;
using System.Linq;

namespace P._03_Generic_Swap_Method_String
{
    public class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var list = new List<Box<string>>();

            for (int i = 0; i < n; i++)
            {
                string element = Console.ReadLine();
                Box<string> box = new Box<string>();
                box.Element = element;

                list.Add(box);
            }

            int[] arr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            SwapList(list, arr);
            PrintList<Box<string>>(list);
        }
        static void PrintList<T>(List<T> list)
        {
            foreach (var element in list)
            {
                Console.WriteLine(element.ToString());
            }
        }
        static List<T> SwapList<T>(List<T> list, int[] indices)
        {
            var firstIndex = indices[0];
            var secondIndex = indices[1];

            T currentElement = list[firstIndex];
            list[firstIndex] = list[secondIndex];
            list[secondIndex] = currentElement;

            return list;
        }

        //or  
        //static void Main(string[] args)
        //{
        //    int n = int.Parse(Console.ReadLine());
        //    var list = new List<string>();

        //    for (int i = 0; i < n; i++)
        //    {
        //        string element = Console.ReadLine();
        //        list.Add(element);
        //    }

        //    int[] indices = Console.ReadLine()
        //        .Split()
        //        .Select(int.Parse)
        //        .ToArray();

        //    SwapList(list, indices);
        //    PrintList<string>(list);
        //}
    }
}
