using System;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string carMake = Console.ReadLine();
            string carName = Console.ReadLine();
            int carYear = int.Parse(Console.ReadLine());
            double fuelQuantity = double.Parse(Console.ReadLine());
            double fuelConsumption = double.Parse(Console.ReadLine());

            var firstCar = new Car();
            var secondCar = new Car(carMake, carName, carYear);
            var thirdCar = new Car(carMake, carName, carYear, fuelQuantity, fuelConsumption);
        }
    }
}
