using System;
using System.Linq;

namespace Array_Rotation
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int rotations = int.Parse(Console.ReadLine());

            for (int i = 0; i < rotations; i++)
            {
                int firstNumber = numbers[0]; //първият елемент ще е този, който е на 0лев индекс

                for (int j = 0; j < numbers.Length - 1; j++) // въртим до предпоследния елемент
                {
                    numbers[j] = numbers[j + 1]; //така сменяме местата на индексите
                }
                numbers[numbers.Length - 1] = firstNumber;//последният индекс ще стане първи
            }
            Console.WriteLine(String.Join(" ", numbers));
        }
    }

}
