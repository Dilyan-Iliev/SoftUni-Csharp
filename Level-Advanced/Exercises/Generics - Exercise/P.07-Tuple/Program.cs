using System;

namespace P._07_Tuple
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i <= 3; i++)
            {
                string[] arr = Console.ReadLine()
                    .Split();

                if (i == 1)
                {
                    string name = $"{arr[0]} {arr[1]}";
                    string adress = arr[2];
                    MyTuple<string, string> tuple = new MyTuple<string, string>();
                    tuple.FirstItem = name;
                    tuple.SecondItem = adress;
                    Console.WriteLine(tuple.ToString());
                }
                else if (i == 2)
                {
                    string name = arr[0];
                    int amountOfBeer = int.Parse(arr[1]);
                    MyTuple<string, int> tuple = new MyTuple<string, int>();
                    tuple.FirstItem = name;
                    tuple.SecondItem = amountOfBeer;
                    Console.WriteLine(tuple.ToString());
                }
                else if (i == 3)
                {
                    int integer = int.Parse(arr[0]);
                    double floatingNumber = double.Parse(arr[1]);
                    MyTuple<int, double> tuple = new MyTuple<int, double>();
                    tuple.FirstItem = integer;
                    tuple.SecondItem = floatingNumber;
                    Console.WriteLine(tuple.ToString());
                }
            }
        }
    }
}
