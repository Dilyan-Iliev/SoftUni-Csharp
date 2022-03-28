using System;
using System.Linq;
using System.Collections.Generic;

namespace Pokemon_Don_t_Go
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> pokemons = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            List<int> removedPokemonsSum = new List<int>();

            while (true)
            {
                int integer = int.Parse(Console.ReadLine());

                if (integer < 0)
                {
                    int removedNumber = pokemons[0];
                    pokemons[0] = pokemons[pokemons.Count - 1];
                    //pokemons.RemoveAt(removedNumber); 
                    //pokemons.Insert(0, pokemons[pokemons.Count - 1]);

                    removedPokemonsSum.Add(removedNumber);

                    for (int i = 0; i < pokemons.Count; i++)
                    {
                        if (removedNumber >= pokemons[i])
                        {
                            pokemons[i] += removedNumber;
                        }
                        else if (removedNumber < pokemons[i])
                        {
                            pokemons[i] -= removedNumber;
                        }
                    }
                }
                else if (integer > pokemons.Count - 1)
                {
                    int removedNumber = pokemons[pokemons.Count - 1];
                    pokemons[pokemons.Count - 1] = pokemons[0];
                    //pokemons.RemoveAt(pokemons.Count - 1);
                    //pokemons.Add(pokemons[0]);

                    removedPokemonsSum.Add(removedNumber);

                    for (int i = 0; i < pokemons.Count; i++)
                    {
                        if (removedNumber >= pokemons[i])
                        {
                            pokemons[i] += removedNumber;
                        }
                        else if (removedNumber < pokemons[i])
                        {
                            pokemons[i] -= removedNumber;
                        }
                    }
                }
                else
                {
                    int indexToRemove = pokemons[integer];
                    pokemons.RemoveAt(integer);

                    removedPokemonsSum.Add(indexToRemove);

                    for (int i = 0; i < pokemons.Count; i++)
                    {
                        if (indexToRemove >= pokemons[i])
                        {
                            pokemons[i] += indexToRemove;
                        }
                        //[5]the other indexes who are greater than the removed index must be decreased widh the value of the removed index
                        else if (indexToRemove < pokemons[i])
                        {
                            pokemons[i] -= indexToRemove;
                        }
                    }
                }

                if (pokemons.Count == 0)
                {
                    break;
                }
            }
            int sum = removedPokemonsSum.Sum();
            Console.WriteLine(sum);

        }
    }
}
