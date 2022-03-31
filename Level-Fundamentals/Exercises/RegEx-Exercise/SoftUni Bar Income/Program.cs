using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SoftUni_Bar_Income
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"^(%(?<customer>[A-Z][a-z]+)%[^|$%.]*<(?<product>\w+)>[^|$%.]*\|(?<quantity>\d+)\|[^|$%.]*?(?<price>[0-9]+\.?[0-9]+)\$)$";

            double totalIncome = 0;

            string input;
            while ((input = Console.ReadLine()) != "end of shift")
            {
                var regex = new Regex(pattern);

                if (regex.IsMatch(input))
                {
                    string customer = regex.Match(input).Groups["customer"].Value;
                    string product = regex.Match(input).Groups["product"].Value;
                    int quantity = int.Parse(regex.Match(input).Groups["quantity"].Value);
                    double price = double.Parse(regex.Match(input).Groups["price"].Value);

                    double total = price * quantity;
                    totalIncome += total;

                    Console.WriteLine($"{customer}: {product} - {total:f2}");
                }
            }
            Console.WriteLine($"Total income: {totalIncome:f2}");
        }
    }
}
