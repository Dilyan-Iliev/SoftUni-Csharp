using System;

namespace Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string mainMethodProduct = Console.ReadLine();
            int mainMethodQuantity = int.Parse(Console.ReadLine());
            ProductFinalPrice(mainMethodProduct, mainMethodQuantity);
        }

        static void ProductFinalPrice(string product, int quantity)
        {
            double totalPrice = 0;
            switch (product)
            {
                case "coffee":
                    totalPrice = quantity * 1.5;
                    break;
                case "water":
                    totalPrice = quantity * 1;
                    break;
                case "coke":
                    totalPrice = quantity * 1.4;
                    break;
                case "snacks":
                    totalPrice = quantity * 2;
                    break;
            }
            Console.WriteLine($"{totalPrice:F2}");
        }
    }
}
