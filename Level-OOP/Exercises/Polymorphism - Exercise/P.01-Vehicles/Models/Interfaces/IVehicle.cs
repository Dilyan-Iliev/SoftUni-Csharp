namespace _8.Models.Interfaces
{

    public interface IVehicle
    {
        double FuelQuantity { get; }

        double FuelConsumptionPerKM { get; }

        string Drive(double distance);

        double Refuel(double fuel);
    }
}
