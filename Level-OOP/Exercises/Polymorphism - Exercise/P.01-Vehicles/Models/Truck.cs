namespace _8.Models
{

    public class Truck : Vehicle
    {
        private const double FuelConsumptionIncrease = 1.6;

        public Truck(double fuelQuantity, double fuelConsumptionPerKM) 
            : base(fuelQuantity, fuelConsumptionPerKM)
        {
            this.FuelConsumptionPerKM += FuelConsumptionIncrease;
        }

        public override double Refuel(double fuel)
        {
            return this.FuelQuantity += (fuel * 0.95);
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {FuelQuantity:f2}";
        }
    }
}
