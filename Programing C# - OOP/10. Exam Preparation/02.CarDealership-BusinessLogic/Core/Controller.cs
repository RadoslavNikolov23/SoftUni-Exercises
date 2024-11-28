using CarDealership.Core.Contracts;
using CarDealership.Models;
using CarDealership.Models.Contracts;
using CarDealership.Models.CustomerTypes;
using CarDealership.Models.TypeVehicles;
using CarDealership.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Core
{
    public class Controller : IController
    {
        private IDealership dealership;

        private string[] customerTypes = new string[]
        {
            typeof(IndividualClient).Name,
            typeof(LegalEntityCustomer).Name
        };

        private string[] vehicleTypes = new string[]
        {
            typeof(SaloonCar).Name,
            typeof(SUV).Name,
            typeof(Truck).Name
        };

        public Controller()
        {
            this.dealership = new Dealership();
        }
        public string AddCustomer(string customerTypeName, string customerName)
        {
            if (!this.customerTypes.Contains(customerTypeName))
                return string.Format(OutputMessages.InvalidType, customerTypeName);

            if (this.dealership.Customers.Exists(customerName))
                return string.Format(OutputMessages.CustomerAlreadyAdded, customerName);

            ICustomer customer = GenerateCustomer(customerTypeName, customerName);
            this.dealership.Customers.Add(customer);
            return string.Format(OutputMessages.CustomerAddedSuccessfully, customerName);
        }


        public string AddVehicle(string vehicleTypeName, string model, double price)
        {
            if (!this.vehicleTypes.Contains(vehicleTypeName))
                return string.Format(OutputMessages.InvalidType, vehicleTypeName);

            if (this.dealership.Vehicles.Exists(model))
                return string.Format(OutputMessages.VehicleAlreadyAdded, model);

            IVehicle vehicle = GenerateVehicle(vehicleTypeName, model, price);
            this.dealership.Vehicles.Add(vehicle);
            return string.Format(OutputMessages.VehicleAddedSuccessfully, vehicleTypeName, model, $"{vehicle.Price:f2}");

        }

        public string PurchaseVehicle(string vehicleTypeName, string customerName, double budget)
        {
            if (!this.dealership.Customers.Exists(customerName))
                return String.Format(OutputMessages.CustomerNotFound, customerName);

            IVehicle[] vehiclesTypesToBuy= this.dealership.Vehicles.Models
                            .Where(v => v.GetType().Name == vehicleTypeName)
                            .ToArray();

            if (vehiclesTypesToBuy.Length==0)
                return String.Format(OutputMessages.VehicleTypeNotFound, vehicleTypeName);

            ICustomer customer = this.dealership.Customers.Get(customerName);
            bool canCustomerByeVehiucle = IsCustomerEligible(customer, vehicleTypeName);

            if (!canCustomerByeVehiucle)
                return string.Format(OutputMessages.CustomerNotEligibleToPurchaseVehicle, customerName, vehicleTypeName);

            IVehicle? vehicle = vehiclesTypesToBuy
                .Where(v => v.Price <= budget)
                .OrderByDescending(v => v.Price).FirstOrDefault();

            if (vehicle != null)
            {
                customer.BuyVehicle(vehicle.Model);
                vehicle.SellVehicle(customer.Name);
                return string.Format(OutputMessages.VehiclePurchasedSuccessfully, customer.Name, vehicle.Model);
            }
            else
            {
                return string.Format(OutputMessages.BudgetIsNotEnough, customerName, vehicleTypeName);
            }
        }

        public string CustomerReport()
        {
            StringBuilder resultSB = new StringBuilder();

            resultSB.AppendLine("Customer Report:");
            foreach (var customer in this.dealership.Customers.Models.OrderBy(c => c.Name))
            {
                resultSB.AppendLine($"{customer}");
                resultSB.AppendLine($"-Models:");
                if (customer.Purchases.Count > 0)
                {
                    foreach (var vehicle in customer.Purchases.OrderBy(m => m))
                    {
                        resultSB.AppendLine($"--{vehicle}");
                    }
                }
                else
                {
                    resultSB.AppendLine("--none");
                }
            }
            return resultSB.ToString().Trim();
        }

        public string SalesReport(string vehicleTypeName)
        {
            StringBuilder resultSB = new StringBuilder();

            resultSB.AppendLine($"{vehicleTypeName} Sales Report:");

            int totalSales = 0;
            foreach (var vehicle in this.dealership.Vehicles.Models
                                .Where(v => v.GetType().Name == vehicleTypeName)
                                .OrderBy(v => v.Model))
            {
                resultSB.AppendLine($"--{vehicle}");
                totalSales += vehicle.SalesCount;
            }
            resultSB.AppendLine($"-Total Purchases: {totalSales}");
            
            return resultSB.ToString().Trim();
        }

        private ICustomer GenerateCustomer(string customerTypeName, string customerName)
        {
            switch (customerTypeName)
            {
                case $"{nameof(IndividualClient)}":
                    return new IndividualClient(customerName);
                case $"{nameof(LegalEntityCustomer)}":
                    return new LegalEntityCustomer(customerName);
                default: return null;
            }

        }

        private IVehicle GenerateVehicle(string vehicleTypeName, string model, double price)
        {
            switch (vehicleTypeName)
            {
                case $"{nameof(SaloonCar)}":
                    return new SaloonCar(model, price);
                case $"{nameof(SUV)}":
                    return new SUV(model, price);
                case $"{nameof(Truck)}":
                    return new Truck(model, price);
                default: return null;
            }
        }

        private bool IsCustomerEligible(ICustomer customer, string vehicleTypeName)
        {
            string customerTypeOf = customer.GetType().Name;
            if (customerTypeOf == typeof(IndividualClient).Name)
            {
                return vehicleTypeName == nameof(SaloonCar) || vehicleTypeName == nameof(SUV);
            }
            else if (customerTypeOf == typeof(LegalEntityCustomer).Name)
            {
                return vehicleTypeName == nameof(SUV) || vehicleTypeName == nameof(Truck);
            }

            return false;
        }

    }
}
