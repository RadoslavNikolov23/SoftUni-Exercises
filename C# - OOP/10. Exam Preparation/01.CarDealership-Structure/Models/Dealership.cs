using CarDealership.Models.Contracts;
using CarDealership.Repositories;
using CarDealership.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models
{
    public class Dealership
    {
        private IRepository<IVehicle> vehicles;
        private IRepository<ICustomer> customers;

        public Dealership()
        {
            vehicles = new VehicleRepository();
            customers = new CustomerRepository();
        }

        public IRepository<IVehicle> Vehicles { get => this.vehicles; }
        public IRepository<ICustomer> Customers { get=>this.customers; }    
    }
}
