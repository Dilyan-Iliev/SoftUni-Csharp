using System;

namespace P._05_Date_Modifier
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string firstDate = Console.ReadLine();
            string secondDate = Console.ReadLine();

            var dateModifier = new DateModifier(firstDate, secondDate);
            Console.WriteLine(dateModifier.CalculateDifferenceBetweenDays(firstDate, secondDate));
        }
    }
}
