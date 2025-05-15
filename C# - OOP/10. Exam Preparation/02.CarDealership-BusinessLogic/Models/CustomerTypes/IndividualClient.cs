using CarDealership.Models.TypeVehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models.CustomerTypes
{
    public class IndividualClient : Customer
    {
        public IndividualClient(string name) : base(name)
        {
        }

    }
}
