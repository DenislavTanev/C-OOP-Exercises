using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Vehicles
{
    public class Truck : Vehicle
    {
        private const double EXT_FUEL_CONS = 1.6;
        public Truck(double fuelQuantity, double fuelConsumption)
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
                return $"Truck travelled {kilometers} km";
            }
            else
            {
                return $"Truck needs refueling";
            }
        }

        public override void Refuel(double fuel)
        {
            this.FuelQuantity += fuel * 0.95;
           
        }

        public override string ToString()
        {
            return $"Truck: {FuelQuantity:f2}";
        }
    }
}
