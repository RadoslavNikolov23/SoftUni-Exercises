using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackFriday.Models
{
    public class Item : Product
    {
        private const double blackFridayPricePrecentForItem=30;
        public Item(string productName, double basePrice) : base(productName, basePrice)
        {
        }

        public override double BlackFridayPrice { get=>this.BasePrice*((100-blackFridayPricePrecentForItem) / 100);}
    }
}
