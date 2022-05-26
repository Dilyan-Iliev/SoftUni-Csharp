using System;

namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            RaceMotorcycle raceMotorcycle = new RaceMotorcycle(100, 50.4);
            FamilyCar familyCar = new FamilyCar(50, 20.3);
        }
    }
}

