using System;
using Vehicles.Contracts;

namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double consumptionPerKm, int tankCapacity)
            : base(fuelQuantity, consumptionPerKm, tankCapacity)
        {

        }
    }
}
