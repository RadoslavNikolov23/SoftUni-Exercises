using CarDealership.Models.TypeVehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models.CustomerTypes
{
    public class LegalEntityCustomer : Customer
    {
        public LegalEntityCustomer(string name) : base(name)
        {
        }

        public override void BuyVehicle(string vehicleModel)
        {
            if (vehicleModel == typeof(Truck).Name || vehicleModel == typeof(SUV).Name)
                base.AddToCollectionWhenBuyingVehicle(vehicleModel);
        }
    }
}
