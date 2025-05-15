using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models.TypeVehicles
{
    public class SaloonCar : Vehicle
    {
        private const double additionCostCoefcient = 1.10;
        public SaloonCar(string model, double price) : base(model, price * additionCostCoefcient)
        {
        }
    }
}
