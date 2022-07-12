namespace _8.Models
{

    public class Car : Vehicle
    {
        private const double FuelConsumptionIncrease = 0.9;

        public Car(double fuelQuantity, double fuelConsumptionPerKM) 
            : base(fuelQuantity, fuelConsumptionPerKM)
        {
            this.FuelConsumptionPerKM += FuelConsumptionIncrease;
        }

        public override double Refuel(double fuel)
         => this.FuelQuantity += fuel;

        public override string ToString()
        {
            return $"{this.GetType().Name}: {FuelQuantity:f2}";
        }
    }
}
