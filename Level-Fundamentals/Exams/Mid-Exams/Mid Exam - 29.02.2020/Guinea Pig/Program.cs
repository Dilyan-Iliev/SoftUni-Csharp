using System;

namespace Guinea_Pig
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double foodQuantity = double.Parse(Console.ReadLine()) * 1000;
            double hayQuantity = double.Parse(Console.ReadLine()) * 1000;
            double coverQuantity = double.Parse(Console.ReadLine()) * 1000;
            double guineaWeight = double.Parse(Console.ReadLine()) * 1000;

            int daysToCover = 30;

            //Every day Puppy eats 300 gr of food
            //Every second day Merry first feeds the pet, then gives it a certain amount of hay equal to 5% of the rest of the food
            //On every third day, Merry puts Puppy cover with a quantity of 1/3 of its weight.

            for (int i = 1; i <= daysToCover; i++)
            {//Calculate whether the quantity of food, hay, and cover, will be enough for a month.

                foodQuantity -= 300;

                if (foodQuantity <= 0 || hayQuantity <=0 || coverQuantity <= 0)
                {
                    Console.WriteLine("Merry must go to the pet store!");
                    return ;
                }

                if (i % 2 == 0)
                {
                    double neededHay = foodQuantity * 0.05;
                    hayQuantity = hayQuantity - neededHay;
                }
                if (i % 3 == 0)
                {
                    double neededCover = guineaWeight / 3;
                    coverQuantity -= neededCover;
                }
            }
            double foodLeftInKg = foodQuantity / 1000;
            double hayLeftInKg = hayQuantity / 1000;
            double coverLeftInKg = coverQuantity / 1000;
            Console.WriteLine($"Everything is fine! Puppy is happy! Food: {foodLeftInKg:f2}, Hay: {hayLeftInKg:f2}, Cover: {coverLeftInKg:f2}.");
        }
    }
}
