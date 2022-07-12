namespace _8.Engine.Interfaces
{
    using _8.Models;

    public interface IController
    {
        Truck CreateTruck(double fuelQuantity, double fuelConsumptionPerKM);

        Car CreateCar(double fuelQuantity, double fuelConsumptionPerKM);
    }
}
