using System;
using System.Linq;

namespace Train
{
    class Program
    {
        static void Main(string[] args)
        {
            int wagons = int.Parse(Console.ReadLine());
            int[] peopleArray = new int[wagons];
            int sum = 0;
            for (int i = 0; i < peopleArray.Length; i++)
            {
                peopleArray[i] = int.Parse(Console.ReadLine());
                sum += peopleArray[i];
            }
            Console.WriteLine(String.Join(" ",peopleArray));
            Console.WriteLine(sum);
        }
    }
}
