using CarDealership.Models.Contracts;
using CarDealership.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models
{
    public abstract class Customer : ICustomer
    {
        private string name;
        private List<string> purchases;

        protected Customer(string name)
        {
            this.Name = name;
            this.purchases = new List<string>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(ExceptionMessages.NameIsRequired);
                this.name = value;
            }
        }
        public IReadOnlyCollection<string> Purchases { get => this.purchases.AsReadOnly(); }

        public abstract void BuyVehicle(string vehicleModel);
        

        protected void AddToCollectionWhenBuyingVehicle(string vehicleModel)
        {
            this.purchases.Add(vehicleModel);
        }


        public override string ToString()
        {
            return $"{this.Name} - Purchases: {this.purchases.Count}";
        }
    }
}
