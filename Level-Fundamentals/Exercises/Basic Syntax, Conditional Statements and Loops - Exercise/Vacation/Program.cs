using System;

namespace Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int groupNum = int.Parse(Console.ReadLine());
            string typeGroup = Console.ReadLine();
            string day = Console.ReadLine();
            decimal price = 0;

            switch (day)
            {
                case "Friday":
                    if (typeGroup == "Students")
                    {
                        price = 8.45M * groupNum;
                        if (groupNum >= 30)
                        {
                            price = price - price * 0.15M;
                        }
                    }
                    else if (typeGroup == "Business")
                    {
                        price = 10.9M * groupNum;
                        if (groupNum >= 100)
                        {
                            price = (groupNum - 10);
                        }
                    }
                    else if (typeGroup == "Regular")
                    {
                        price = 15 * groupNum;
                        if (groupNum>=10 && groupNum <= 20)
                        {
                            price = price - price * 0.05M;
                        }
                    }
                    break;
                case "Saturday":
                    if (typeGroup == "Students")
                    {
                        price = 9.8M * groupNum;
                        if (groupNum >= 30)
                        {
                            price = price - price * 0.15M;
                        }
                    }
                    else if (typeGroup == "Business")
                    {
                        price = 15.6M * groupNum;
                        if (groupNum >= 100)
                        {
                            price = (groupNum - 10);
                        }
                    }
                    else if (typeGroup == "Regular")
                    {
                        price = 20 * groupNum;
                        if (groupNum >= 10 && groupNum <= 20)
                        {
                            price = price - price * 0.05M;
                        }
                    }
                    break;
                case "Sunday":
                    if (typeGroup == "Students")
                    {
                        price = 10.46M * groupNum;
                        if (groupNum >= 30)
                        {
                            price = price - price * 0.15M;
                        }
                    }
                    else if (typeGroup == "Business")
                    {
                        price = 16 * groupNum;
                        if (groupNum >= 100)
                        {
                            price = price * (groupNum-10);
                        }
                    }
                    else if (typeGroup == "Regular")
                    {
                        price = 22.5M * groupNum;
                        if (groupNum >= 10 && groupNum <= 20)
                        {
                            price = price - price * 0.05M;
                        }
                    }
                    break;
            }
            

            Console.WriteLine($"Total price: {price:F2}");

        }
    }
}
