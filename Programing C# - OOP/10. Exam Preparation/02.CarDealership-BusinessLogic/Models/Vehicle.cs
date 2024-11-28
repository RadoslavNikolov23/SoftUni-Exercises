using CarDealership.Models.Contracts;
using CarDealership.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models
{
    public abstract class Vehicle : IVehicle
    {
        private string model;
        private double price;
        private List<string> buyers;

        protected Vehicle(string model, double price)
        {
            this.Model = model;
            this.Price = price;
            this.buyers = new List<string>();
        }

        public string Model
        {
            get => this.model;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(ExceptionMessages.ModelIsRequired);
                this.model = value;
            }
        }
        public double Price
        {
            get => this.price;
            private set
            {
                if (value<=0)
                    throw new ArgumentException(ExceptionMessages.PriceMustBePositive);
                this.price = value;
            }
        }

        public IReadOnlyCollection<string> Buyers { get => this.buyers.AsReadOnly(); }
        public int SalesCount { get => this.Buyers.Count; }

        public void SellVehicle(string buyerName)
        {
            buyers.Add(buyerName);
        }

        public override string ToString()
        {
            return $"{this.Model} - Price: {this.Price:f2}, Total Model Sales: {this.SalesCount}";
        }
    }
}
