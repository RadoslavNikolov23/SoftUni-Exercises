using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackFriday.Models
{
    public class Service : Product
    {
        private const double blackFridayPricePrecentForService = 20;

        public Service(string productName, double basePrice) : base(productName, basePrice)
        {
        }

        public override double BlackFridayPrice { get => this.BasePrice * ((100-blackFridayPricePrecentForService) / 100); }
    }
}
