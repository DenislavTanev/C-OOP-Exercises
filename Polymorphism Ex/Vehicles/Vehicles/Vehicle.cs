using Vehicles.Contracts;

namespace Vehicles.Vehicles
{
    public abstract class Vehicle : IDrive, IRefuel
    {
        public Vehicle(double fuelQuantity, double fuelConsumption)
        {
            this.FuelConsumption = fuelConsumption;
            this.FuelQuantity = fuelQuantity;
        }
        public abstract double FuelConsumption { get; set; }
        public abstract double FuelQuantity { get; set; }

        public abstract string Drive(double kilometers);

        public abstract void Refuel(double fuel);
      
        public abstract override string ToString();
    }
}
