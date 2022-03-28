using System;
using System.Linq;

namespace Common_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] firstArray = Console.ReadLine()
                .Split()
                .ToArray();

            string[] secondArray = Console.ReadLine()
                .Split()
                .ToArray();

            for (int i = 0; i < secondArray.Length; i++)//You have to compare the elements of the second array to the elements of the first.
            {
                for (int j = 0; j < firstArray.Length; j++) // нужен е вложен цикъл за да можем всеки индекс от secondArray да сравним със
                                                            //всеки индекс от firstArray -> secondArray[0] със firstArray[1] , [2] и т.н. доколкото е дълъг firstArray. 
                                                            //След това secondArray[1] по съшия начин.
                {
                    if (secondArray[i] == firstArray[j])
                    {
                        Console.Write(secondArray[i] + " ");
                    }
                }
            }



        }
    }
}
