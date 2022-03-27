using System;

namespace VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            //read a num (this will be the coins until we get a "Start" command
            //run a while loop with if or switch in it
            //read product and put product price
            //run a while loop until we get "End" command

            string input = Console.ReadLine();
            double coinSum = 0;


            while (input != "Start")
            {
                double coin = double.Parse(input);
                if (coin == 0.1 ||
                    coin == 0.2 ||
                    coin == 0.5 ||
                    coin == 1 ||
                    coin == 2)
                {
                    coinSum += coin;
                }
                else
                {
                    Console.WriteLine($"Cannot accept {coin}");
                }
                input = Console.ReadLine();
            }
            string product = Console.ReadLine();
           

            while (product != "End")
            {
                double productPrice = 0; //така се занулява след всяка итерация

                switch (product)
                {
                    case "Nuts": productPrice = 2; break;
                    case "Water": productPrice = 0.7; break;
                    case "Crisps": productPrice = 1.5; break;
                    case "Soda": productPrice = 0.8; break;
                    case "Coke": productPrice = 1; break;
                    default: Console.WriteLine("Invalid product"); break;
                }

                if (coinSum >= productPrice && productPrice > 0) //задава се >0, тъй като само входните продукти имат съответна цена
                {
                    Console.WriteLine($"Purchased {product.ToLower()}");
                    coinSum = coinSum - productPrice;
                    
                }
                else if (productPrice > 0)  //задава се >0, тъй като само входните продукти имат съответна цена и ще влезем в този else if 
                {
                    Console.WriteLine("Sorry, not enough money");
                   
                }

                product = Console.ReadLine();
            }
            Console.WriteLine($"Change: {coinSum:F2}");
        }
    }
}
