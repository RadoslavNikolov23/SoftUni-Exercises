using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models.TypeVehicles
{
    public class Truck : Vehicle
    {
        private const double additionCostCoefcient = 1.30;
        public Truck(string model, double price) : base(model, price * additionCostCoefcient)
        {
        }

    }
}
