using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Contracts;

namespace Vehicles.Models
{
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double consumptionPerKm, int tankCapacity)
            : base(fuelQuantity, consumptionPerKm, tankCapacity)
        {

        }
    }
}
