using System;

namespace Rage_Expenses
{
    class Program
    {
        static void Main(string[] args)
        {
            int lostGames = int.Parse(Console.ReadLine());
            double headSetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());

            int headSetcount = 0;
            int mouseCount = 0;
            int keyboardCount = 0;
            int displayCount = 0;

            double sum = 0;

            for (int i = 1; i <= lostGames; i++)
            {
                //при if-a i-то показва на коя загубена игра сме вмомента
                if (i % 2 == 0)
                {
                    headSetcount++;
                    sum += headSetPrice;
                }
                if (i % 3 == 0)
                {
                    mouseCount++;
                    sum += mousePrice;
                }
                if (i % 2 == 0 && i % 3 == 0)
                {
                    keyboardCount++;
                    sum += keyboardPrice;
                }
                if (i % 12 == 0)
                {
                    displayCount++;
                    sum += displayPrice;
                }

            }
            /*double sum = (headSetcount * headSetPrice) +
                (mouseCount * mousePrice) +
                (keyboardCount * keyboardPrice) +
                (displayCount * displayPrice); -> в случай, че не ги смятам във For цикъла*/
            Console.WriteLine($"Rage expenses: {sum:F2} lv.");
        }
    }
}
