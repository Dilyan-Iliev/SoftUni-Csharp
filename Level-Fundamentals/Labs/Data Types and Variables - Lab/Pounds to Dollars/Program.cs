using System;

namespace Pounds_to_Dollars
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal britishPound = decimal.Parse(Console.ReadLine()); //ако е с double Judge не дава 100/100
            decimal US = (decimal)1.31;
            Console.WriteLine($"{(US*britishPound):F3}");
        }
    }
}
