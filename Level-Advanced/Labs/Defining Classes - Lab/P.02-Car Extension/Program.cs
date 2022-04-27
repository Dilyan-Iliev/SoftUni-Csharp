using System;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            //make it universal

            string carMake = Console.ReadLine();
            string carModel = Console.ReadLine();
            int carYear = int.Parse(Console.ReadLine());
            double fuelQuantity = double.Parse(Console.ReadLine());
            double fuelConsumption = double.Parse(Console.ReadLine());

            var car = new Car(carMake, carModel, carYear, fuelQuantity, fuelConsumption);

            double distanceToGo = double.Parse(Console.ReadLine());
           
            car.Drive(distanceToGo);
            Console.WriteLine(car.WhoAmI());
        }
    }
}
