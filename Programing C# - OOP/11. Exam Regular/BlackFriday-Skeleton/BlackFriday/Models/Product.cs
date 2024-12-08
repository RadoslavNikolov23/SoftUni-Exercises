using BlackFriday.Models.Contracts;
using BlackFriday.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackFriday.Models
{
    public abstract class Product : IProduct
    {
        public Product(string productName, double basePrice)
        {
            if (string.IsNullOrWhiteSpace(productName))
                throw new ArgumentException(ExceptionMessages.ProductNameRequired);

            if (basePrice <= 0)
                throw new ArgumentException(ExceptionMessages.ProductPriceConstraints);

            ProductName = productName;
            BasePrice = basePrice;
            IsSold = false;
        }

        public string ProductName { get; }
        public double BasePrice { get; private set; }
        public virtual double BlackFridayPrice { get; }
        public bool IsSold { get; private set; }

        public void ToggleStatus()
        {
            if (IsSold)
                IsSold = false;
            else
                IsSold = true;
        }

        public void UpdatePrice(double newPriceValue) => this.BasePrice = newPriceValue;

        public override string ToString() => $"Product: {this.ProductName}, Price: {this.BasePrice:F2}, You Save: {(this.BasePrice - this.BlackFridayPrice):F2}";
    }
}
