using System;

namespace Black_Flag
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int daysForPlunder = int.Parse(Console.ReadLine());
            int dailyPlunder = int.Parse(Console.ReadLine());
            double expectedPlunder = double.Parse(Console.ReadLine());

            double plunderCollected = 0;
            //that checks if target plunder is reached
            for (int i = 1; i <= daysForPlunder; i++)
            {//Each day they gather the plunder
             //they attack more ships every third day and add additional plunder to their total gain, which is 50% of the daily plunder. 
             //Every fifth day the pirates encounter a warship, and after the battle, they lose 30% of their total plunder

                plunderCollected += dailyPlunder;

                if (i % 3 == 0)
                {
                    double additionalPlunder = dailyPlunder * 0.5;
                    plunderCollected += additionalPlunder;
                }
                if (i % 5 == 0)
                {
                    double plunderLost = plunderCollected * 0.3;
                    plunderCollected -= plunderLost;
                }
            }
                if (plunderCollected >= expectedPlunder)
                {
                    Console.WriteLine($"Ahoy! {plunderCollected:f2} plunder gained.");
                }
                else if (plunderCollected < expectedPlunder)
                {
                double leftPlunder =  (plunderCollected /expectedPlunder) *100;
                Console.WriteLine($"Collected only {leftPlunder:f2}% of the plunder.");
                }
        }
    }
}
