using System;
using System.Collections.Generic;
using System.Linq;

namespace P._06_Generic_Count_Method_Double
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Box<double>> list = new List<Box<double>>();

            for (int i = 0; i < n; i++)
            {
                double element = double.Parse(Console.ReadLine());
                Box<double> box = new Box<double>();
                box.Element = element;

                list.Add(box);
            }

            double elementForComparison = double.Parse(Console.ReadLine());
            
            Console.WriteLine(CompareElements(list, elementForComparison));
        }

        static int CompareElements<T>(List<Box<T>> list, T elementForComparison)
            where T : IComparable<T>
        {
            var filteredList = list
                .Where(x => x.Compare(elementForComparison) > 0);

            return filteredList.Count();
        }
    }
}
