using System;
using System.Linq;
namespace Max_Sequence_of_Equal_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                            .Split()
                            .Select(int.Parse)
                            .ToArray();

            int counter = 0;
            int winningIndex = 0;
            int winningCounter = 0;
            string number = string.Empty;

            for (int i = 0; i < numbers.Length-1; i++)//numbers.Lenght - 1 понеже в if-а имаме i+1 и в противен случай ще излезем извън масива
            {
                if (numbers[i] == numbers[i + 1]) 
                {
                    counter++; //увеличаваме counter-a
                   

                    if (counter > winningCounter) //ако counter > от winningCounter 
                    {
                        winningCounter = counter;
                        winningIndex = i;
                        number=numbers[i].ToString();
                    }

                }
                else
                {
                    counter = 0; //зануляваме counter ако numbers[i]!=numbers[i+1]
                }
            }
            for (int i = 0; i <= winningCounter; i++)
            {
                Console.Write(number + " ");
            }
        }
    }
}

