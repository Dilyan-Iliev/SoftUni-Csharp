using System;

namespace Top_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            long number = long.Parse(Console.ReadLine());
            NumberIsDivisible(number);
        }

        static void NumberIsDivisible(long number)
        {
            //int count = 1; // =1 за да е колкото i когато започне цикъла

            for (int i = 1; i <= number; i++)
            {
                int count = i; //правя =i, понеже след всяка итерация count ще се занулява и след това ще го обновя да е колкото i
                int sumDigits = 0; //sum се занулява след всяка итерация на for цикъла
                bool oddDigit = false;
                while (count > 0)
                {
                    int lastDigit = count % 10;
                    sumDigits += lastDigit;

                    if (lastDigit % 2 != 0)
                    {
                        oddDigit = true;
                    }
                    
                    count /= 10;
                }
                if (sumDigits % 8 == 0 && oddDigit==true)
                {
                    Console.WriteLine(i);
                }
            }


        }
    }
}
