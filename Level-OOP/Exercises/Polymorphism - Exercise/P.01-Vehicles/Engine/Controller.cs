namespace _8.Engine
{
    using _8.Models;
    using _8.Engine.Interfaces;

    public class Controller : IController
    {
        public Car CreateCar(double fuelQuantity, double fuelConsumptionPerKM)
         => new Car(fuelQuantity, fuelConsumptionPerKM);

        public Truck CreateTruck(double fuelQuantity, double fuelConsumptionPerKM)
         => new Truck(fuelQuantity, fuelConsumptionPerKM);
    }
}
