using System;

namespace P._08_Threeuple
{
    public class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i <= 3; i++)
            {
                string[] arr = Console.ReadLine()
                    .Split(' ');

                if(i == 1)
                {
                    string firstAndLastName = $"{arr[0]} {arr[1]}";
                    string adress = arr[2];
                    string town = string.Empty;
                    if (arr.Length > 4)
                    {
                        town = $"{arr[3]} {arr[4]}";
                    }
                    else
                    {
                        town = arr[3];
                    }

                    Threeuple<string, string, string> threeuple = new Threeuple<string, string, string>();
                    threeuple.FirstParam = firstAndLastName;
                    threeuple.SecondParam = adress;
                    threeuple.ThirdParam = town;
                    Console.WriteLine(threeuple.ToString());
                    
                }
                else if (i == 2)
                {
                    string name = arr[0];
                    int liters = int.Parse(arr[1]);
                    bool isDrunk = arr[2] == "drunk" ? true : false;

                    Threeuple<string, int, bool> threeuple = new Threeuple<string, int, bool>();
                    threeuple.FirstParam = name;
                    threeuple.SecondParam = liters;
                    threeuple.ThirdParam = isDrunk;
                    Console.WriteLine(threeuple.ToString());
                }
                else if (i == 3)
                {
                    string name = arr[0];
                    double accountBalance = double.Parse(arr[1]);
                    string bankName = arr[2];

                    Threeuple<string, double, string> threeuple = new Threeuple<string, double, string>();
                    threeuple.FirstParam = name;
                    threeuple.SecondParam = accountBalance;
                    threeuple.ThirdParam = bankName;
                    Console.WriteLine(threeuple.ToString());
                }
            }
        }
    }
}
