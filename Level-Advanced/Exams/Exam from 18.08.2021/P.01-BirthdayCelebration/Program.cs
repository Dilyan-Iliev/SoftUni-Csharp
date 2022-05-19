using System;
using System.Linq;
using System.Collections.Generic;

namespace P._01_BirthdayCelebration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] guestsCapacity = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] plates = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> guestsQueue = new Queue<int>(guestsCapacity);
            Stack<int> platesStack = new Stack<int>(plates);

            int wastedFood = 0;

            while (guestsQueue.Any() && platesStack.Any())
            {
                int currentGuest = guestsQueue.Peek();
                int currentPlate = platesStack.Peek();

                int result = 0;
                if (currentPlate >= currentGuest)
                {
                    //If a plate's value is greater or equal to the guest's current value,
                    //you fill up the guest and the remaining food becomes wasted

                    result = currentPlate - currentGuest;
                    wastedFood += result;

                    platesStack.Pop();
                    guestsQueue.Dequeue();
                }
                else
                {
                    //It is possible that the current guest's value is greater than the current food's value.
                    //In that case you pick plates until you reduce the guest's integer value to 0 or less.

                    guestsQueue.Dequeue();
                    platesStack.Pop();

                    result = currentGuest - currentPlate;
                    guestsQueue = new Queue<int>(guestsQueue.Reverse());
                    guestsQueue.Enqueue(result);
                    guestsQueue = new Queue<int>(guestsQueue.Reverse());
                }
            }

            if (platesStack.Any())
            {
                Console.WriteLine($"Plates: {string.Join(" ", platesStack)}");
            }
            else if (guestsQueue.Any())
            {
                Console.WriteLine($"Guests: {string.Join(" ", guestsQueue)}");
            }
            Console.WriteLine($"Wasted grams of food: {wastedFood}");
        }
    }
}
