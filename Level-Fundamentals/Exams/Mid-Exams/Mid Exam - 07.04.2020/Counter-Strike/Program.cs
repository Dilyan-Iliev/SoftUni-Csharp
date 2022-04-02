using System;

namespace Counter_Strike
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int startingEnergy = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();

            int winsCounter = 0;

            while (input != "End of battle")
            {
                int distance = int.Parse(input);//The energy you need for reaching an enemy is equal to the distance you receive. 

                if (startingEnergy - distance >= 0)
                {//Every third won battle increases your energy with the value of your current count of won battles.
                    winsCounter++;
                    startingEnergy -= distance;
                    if (winsCounter % 3 == 0)
                    {
                        startingEnergy += winsCounter;
                    }
                }
                else if (startingEnergy - distance < 0)
                {
                    Console.WriteLine($"Not enough energy! Game ends with {winsCounter} won battles and {startingEnergy} energy");
                    return;
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"Won battles: {winsCounter}. Energy left: {startingEnergy}");
        }
    }
}
