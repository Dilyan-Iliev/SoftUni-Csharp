using System;
using System.Collections.Generic;
using System.Linq;

namespace Store_Boxes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Box> items = new List<Box>();
            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                string[] inputArgs = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                Box box = new Box(); //object box
                box.SerialNumber = inputArgs[0];
                box.Item = inputArgs[1];
                box.ItemQuantity = int.Parse(inputArgs[2]);
                box.PriceBox = decimal.Parse(inputArgs[3]);
                box.TotalPrice = box.ItemQuantity * box.PriceBox;

                items.Add(box);
            }
            List<Box> orderedItems = items.OrderByDescending(items => items.TotalPrice).ToList(); 
            foreach (var item in orderedItems)
            {
                Console.WriteLine($"{item.SerialNumber}");
                Console.WriteLine($"-- {item.Item} - ${item.PriceBox:f2}: {item.ItemQuantity}");
                Console.WriteLine($"-- ${item.TotalPrice:f2}");

            }
        }
    }

    class Box
    {
        
        public string SerialNumber { get; set; }
        public string Item { get; set; }
        public int ItemQuantity { get; set; }
        public decimal PriceBox { get; set; }
        public decimal TotalPrice { get; set; }

    }
}
