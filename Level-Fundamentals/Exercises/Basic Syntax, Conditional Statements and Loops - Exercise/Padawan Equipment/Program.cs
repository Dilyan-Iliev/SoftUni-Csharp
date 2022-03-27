using System;

namespace Padawan_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {


            double money = double.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            double sabrePrice = double.Parse(Console.ReadLine());
            double robePrice = double.Parse(Console.ReadLine());
            double beltPrice = double.Parse(Console.ReadLine());

            double neededSabers =sabrePrice *(Math.Ceiling(students* 0.1 + students));
            double neededRobes = robePrice * students;
            double neededBelts = beltPrice * students;
            int freeBelts = students / 6;

            double total = neededRobes + neededSabers + ((students-freeBelts)*beltPrice);
            if (total <= money)
            {
                Console.WriteLine($"The money is enough - it would cost {total:F2}lv.");
            }
            else
            {
                Console.WriteLine($"John will need {(total-money):F2}lv more.");
            }



        }
    }
}
