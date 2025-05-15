using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models.TypeVehicles
{
    public class SUV : Vehicle
    {
        private const double additionCostCoefcient = 1.20;
        public SUV(string model, double price) : base(model, price * additionCostCoefcient)
        {
        }
    }
}
