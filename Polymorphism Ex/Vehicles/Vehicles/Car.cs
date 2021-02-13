namespace Vehicles.Vehicles
{
    public class Car : Vehicle
    {
        private const double EXT_FUEL_CONS = 0.9;
        public Car(double fuelQuantity, double fuelConsumption)
            :base(fuelQuantity, fuelConsumption)
        {
            this.FuelConsumption += EXT_FUEL_CONS;
        }
        public override double FuelConsumption { get; set; }
        public override double FuelQuantity { get; set; }

        public override string Drive(double kilometers)
        {
            
            double fuelNeeded = kilometers * this.FuelConsumption;
            if (this.FuelQuantity >= fuelNeeded)
            {
                this.FuelQuantity -= fuelNeeded;
                return $"Car travelled {kilometers} km";
            }
            else
            {
                return $"Car needs refueling";
            }
            
        }

        public override void Refuel(double fuel)
        {
            this.FuelQuantity += fuel;
        }

        public override string ToString()
        {
            return $"Car: {FuelQuantity:f2}";
        }
    }
}
