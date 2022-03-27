using System;

namespace StrongNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            /*read a number
             get the last digit of this number 
            remove the last digit with %10 and /10
            sum all factorials
            compare the number and the sum*/

            int consoleNum = int.Parse(Console.ReadLine());
            int num = consoleNum;
            int sum = 0;

            while (num>0)//понеже при модулното деление махаме по едно число отзад-напред -> докато не остане 0 
            {
                int loopNum = num % 10;
                num = num / 10;

                int factorial = 1; //factorial е напр. ако имаме числото 3 -> 3*2*1 
                for (int i = 1; i <= loopNum; i++)
                {
                    factorial *= i;
                }
                sum += factorial;
            }

            if (sum == consoleNum)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
            


        }
    }
}
