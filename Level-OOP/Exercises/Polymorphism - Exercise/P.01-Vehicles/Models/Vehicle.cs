namespace _8.Models
{
    using _8.Models.Interfaces;
    using System.Text;

    public abstract class Vehicle : IVehicle
    {
        protected Vehicle(double fuelQuantity, double fuelConsumptionPerKM)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumptionPerKM = fuelConsumptionPerKM;
        }

        public double FuelQuantity { get; protected set; }

        public virtual double FuelConsumptionPerKM { get; protected set; }

        public virtual string Drive(double distance) 
        {                                            
            bool isEnoughFuel = distance * FuelConsumptionPerKM <= FuelQuantity;

            if (!isEnoughFuel)
            {
                throw new System.InvalidOperationException($"{this.GetType().Name} needs refueling");
            }

            FuelQuantity -= distance * FuelConsumptionPerKM;
            return $"{this.GetType().Name} travelled {distance} km";
        }

        public abstract double Refuel(double fuel);
    }
}
