using Vehicles.Contracts;

namespace Vehicles.Models
{
    public class Bus : Vehicle
    {
        public Bus(double fuelQuantity, double consumptionPerKm, int tankCapacity)
             : base(fuelQuantity, consumptionPerKm, tankCapacity)
        {
        }
    }
}
