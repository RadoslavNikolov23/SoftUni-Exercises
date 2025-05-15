using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles.Interface
{
    public interface IVehicle
    {
        double FuelQuantity { get; }
        double FuelConsumption { get; }

        bool Driven(double driveKM);

        void Refueled(double liters);
    }
}
