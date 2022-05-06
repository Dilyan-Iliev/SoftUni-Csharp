using System;
using System.Collections.Generic;
using System.Linq;

namespace P._04_Generic_Swap_Method_Integer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int numberOfLines = int.Parse(Console.ReadLine());

            var list = new List<Box<int>>();

            for (int i = 0; i < numberOfLines; i++)
            {
                int element = int.Parse(Console.ReadLine());

                Box<int> box = new Box<int>();
                box.Element = element;

                list.Add(box);  
            }

            int[] indicesForSwap = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            SwapElements(list, indicesForSwap);
            PrintOutput(list);
        }

        static List<T> SwapElements<T>(List<T> list, int[] indicesForSwap)
        {
            int firstIndex = indicesForSwap[0];
            int secondIndex = indicesForSwap[1];

            T currentElement = list[firstIndex];
            list[firstIndex] = list[secondIndex];
            list[secondIndex] = currentElement;

            return list;
        }

        static void PrintOutput<T>(List<T> list)
        {
            foreach (var element in list)
            {
                Console.WriteLine(element.ToString());
            }
        }
    }
}
