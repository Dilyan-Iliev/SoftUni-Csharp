using System;

namespace Computer_Store
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            double totalPriceWithouTaxes = 0;
            bool isSpecial = false;
            while (true)
            {
                if (command == "special")
                {
                    isSpecial = true;
                    break;
                }
                if (command == "regular")
                {
                    break;
                }
                double partPrice = double.Parse(command);

                if (partPrice < 0)
                {
                    Console.WriteLine("Invalid price!");
                    command = Console.ReadLine();
                    continue;
                }
                totalPriceWithouTaxes += partPrice;

                command = Console.ReadLine();
            }

            double tax = totalPriceWithouTaxes * 0.2;
            double finalPrice = totalPriceWithouTaxes + tax;
            if (finalPrice == 0)
            {
                Console.WriteLine("Invalid order!");
                return;
            }
            else
            {
                Console.WriteLine("Congratulations you've just bought a new computer!");
                Console.WriteLine($"Price without taxes: {totalPriceWithouTaxes:f2}$");
                Console.WriteLine($"Taxes: {tax:f2}$");
                Console.WriteLine("-----------");
                if (isSpecial)
                {
                    finalPrice = finalPrice - (finalPrice * 0.1);
                }
                else
                {
                    finalPrice = finalPrice;
                }

                Console.WriteLine($"Total price: {finalPrice:f2}$");
            }

        }
    }
}
