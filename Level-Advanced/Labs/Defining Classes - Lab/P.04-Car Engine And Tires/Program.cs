using System;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var tires = new Tire[4]
            {
                new Tire(1995, 1.2),
                new Tire(1992, 1.9),
                new Tire(2010, 1.4),
                new Tire(2018, 2.9)
            };

            var engine = new Engine(120, 3600);

            var car = new Car("VW", "Golf", 2008, 199, 15, engine, tires);
        }
    }
}

