using System;


namespace PokeMon
{
    class Program
    {
        static void Main(string[] args)
        {
            int pokePowerN = int.Parse(Console.ReadLine());
            int distanceM = int.Parse(Console.ReadLine());
            int exhaustionFactorY = int.Parse(Console.ReadLine());

            int currentPokePower = pokePowerN;
            int targetsCount = 0;

            while (currentPokePower >= distanceM)
            {
                currentPokePower -= distanceM;
                targetsCount++;

                if (currentPokePower == pokePowerN * 0.5 && exhaustionFactorY != 0)
                {
                    currentPokePower /= exhaustionFactorY;
                }
            }

            Console.WriteLine(currentPokePower);
            Console.WriteLine(targetsCount);
        }
    }
}
